namespace FitnessClub.Domain.Tests;
/// <summary>
/// Класс тестов для запросов бронирования
/// </summary>
/// 
public class BookingQueriesTests(BookingQueriesFixture fixture) : IClassFixture<BookingQueriesFixture>
{
    /// <summary>
    /// Зафиксированный момент времени
    /// </summary>
    private readonly DateTime _checkTime = new(2026, 9, 15, 10, 30, 0);
    /// <summary>
    /// Вывести информацию о всех тренерах, стаж работы которых не менее 5 лет. 
    /// </summary>
    [Fact]
    public void ExperiencedTrainers_ShouldHaveAtLeast5YearsExperience()
    {
        //Arrange
        var expectedFullNames = new[]
        {
            fixture.Trainers[0].FullName,
            fixture.Trainers[2].FullName,
            fixture.Trainers[3].FullName,
            fixture.Trainers[5].FullName,
            fixture.Trainers[6].FullName,
            fixture.Trainers[7].FullName,
            fixture.Trainers[8].FullName,
            fixture.Trainers[9].FullName
        };
        //Act
        var result = fixture.Trainers.Where(t => t.Experience >= 5).ToList();
        //Assert
        Assert.NotEmpty(result);
        Assert.Equal(expectedFullNames, result.Select(t => t.FullName));
    }
    /// <summary>
    /// Вывести информацию о клиентах, у которых просрочен абонемент, упорядочить по ФИО. 
    /// </summary>
    [Fact]
    public void ClientsWithOverdueSubscriptions_ShouldBeOrderedByFullName()
    {
        //Arrange
        var checkDate = DateOnly.FromDateTime(_checkTime.Date);
        var expectedFullNames = new[]
        {
            fixture.Clients[11].FullName,
            fixture.Clients[10].FullName,
            fixture.Clients[2].FullName,
            fixture.Clients[4].FullName
        };
        //Act
        var result = fixture.Clients
            .Where(c => c.SubscriptionEnd < checkDate)
            .OrderBy(c => c.FullName)
            .ToList();
        //foreach (var c in result) Console.WriteLine($"\"{c.FullName}\",");
        //Assert
        Assert.NotEmpty(result);
        Assert.Equal(expectedFullNames, result.Select(c => c.FullName));
        //Assert.True(result.SequenceEqual(result.OrderBy(c => c.FullName, StringComparer.Ordinal)));

    }
    /// <summary>
    /// Вывести топ 5 наиболее популярных тренеров.
    /// </summary>
    [Fact]
    public void MostPopularTrainers_ShouldBeOrderedByNumberOfBookings()
    {
        //Arrange
        //Act
        var result = fixture.Bookings
            .GroupBy(b => b.Trainer)
            .Select(g => new { Trainer = g.Key, BookingCount = g.Count() })
            .OrderByDescending(t => t.BookingCount)
            .Take(5)
            .ToList();
        //Assert
        Assert.NotEmpty(result);
        Assert.Equal(5, result.Count);
        for (var i = 0; i < result.Count - 1; i++)
        {
            Assert.True(result[i].BookingCount >= result[i + 1].BookingCount);
        }
    }
    /// <summary>
    /// Проверить, является ли зал доступным для записи в данный момент. 
    /// </summary>
    [Fact]
    public void Hall_ShouldBeUnavailable_WhenBookingOverlapsCheckTime()
    {
        //Arrange
        var checkTime = _checkTime;
        var busyHall = fixture.Halls[4];
        //Act
        var result = fixture.Bookings
            .Where(b => b.DateTime < checkTime + Booking.Duration &&
                        checkTime < b.DateTime + Booking.Duration)
            .Select(h => h.Hall)
            .ToList();
        //Assert
        Assert.NotEmpty(result);
        Assert.Contains(busyHall, result);
    }
    /// <summary>
    /// Вывести информацию о занятиях за текущий месяц, проходящих в выбранном зале.
    /// </summary>
    [Fact]
    public void SessionsInTheChosenHall_ShouldBeFilteredByCurrentMonth()
    {
        //Arrange
        var checkDate = DateOnly.FromDateTime(_checkTime.Date);
        var chosenHall = fixture.Halls[0];
        //Act
        var result = fixture.Bookings
            .Where(b => b.Hall == chosenHall &&
                        b.DateTime.Month == checkDate.Month &&
                        b.DateTime.Year == checkDate.Year)
            .ToList();
        //Assert
        Assert.NotEmpty(result);
        Assert.All(result, b => Assert.Equal(chosenHall, b.Hall));
        Assert.All(result, b => Assert.Equal(checkDate.Month, b.DateTime.Month));
        Assert.All(result, b => Assert.Equal(checkDate.Year, b.DateTime.Year));
    }
    /// <summary>
    /// Проверить, занят ли зал на указанное время проверки.
    /// Время проверки задаётся полем <c>_checkTime</c>.
    /// </summary>
    [Fact]
    public void Hall_ShouldBeOccupied_WhenBookingOverlapsCheckTime()
    {
        //Arrange
        var checkTime = _checkTime;
        var busyHall = fixture.Halls[4];
        //Act
        var result = fixture.Bookings
            .Where(b => b.DateTime < checkTime + Booking.Duration &&
                        checkTime < b.DateTime + Booking.Duration)
            .Select(h => h.Hall)
            .ToList();
        //Assert
        Assert.NotEmpty(result);
        Assert.Contains(busyHall, result);
    }
}