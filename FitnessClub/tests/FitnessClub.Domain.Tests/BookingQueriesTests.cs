namespace FitnessClub.Domain.Tests;

public class BookingQueriesTests(BookingQueriesFixture fixture) : IClassFixture<BookingQueriesFixture>
{
    private readonly BookingQueriesFixture _fixture = fixture;
    private readonly DateTime _checkTime = new(2026, 9, 15, 10, 30, 0);

    [Fact]
    public void ExperiencedTrainers_ShouldHaveAtLeast5YearsExperience()
    {
        // Arrange
        //Act
        var result = _fixture.Trainers.Where(t => t.Experience >= 5).ToList();
        //Assert
        Assert.NotEmpty(result);
        Assert.All(result, t => Assert.True(t.Experience >= 5));
    }

    [Fact]
    public void ClientsWithOverdueSubscriptions_ShouldBeOrderedByFullName()
    {
        //Arrange
        var checkDate = DateOnly.FromDateTime(_checkTime.Date);
        //Act
        var result = _fixture.Clients
            .Where(c => c.SubscriptionEnd < checkDate)
            .OrderBy(c => c.FullName)
            .ToList();
        //Assert
        Assert.NotEmpty(result);
        Assert.All(result, c => Assert.True(c.SubscriptionEnd < checkDate));
    }
    [Fact]
    public void MostPopularTrainers_ShouldBeOrderedByNumberOfBookings()
    {
        //Arrange
        //Act
        var result = _fixture.Bookings
            .GroupBy(b => b.Trainer)
            .Select(g => new { Trainer = g.Key, BookingCount = g.Count()})
            .OrderByDescending(t => t.BookingCount)
            .Take(5)
            .ToList();
        //Assert
        Assert.NotEmpty(result);
        Assert.Equal(5, result.Count);
        for (int i = 0; i < result.Count - 1; i++)
        {
            Assert.True(result[i].BookingCount >= result[i + 1].BookingCount);
        }

    }
    [Fact]
    public void Hall_ShouldBeUnavailable_WhenBookingOverlapsCheckTime()
    {
        //Arrange
        var checkTime = _checkTime;
        var busyHall = _fixture.Halls[4];
        //нужна, чтобы точно что-то пересеклось
        var overlappingBooking = new Booking
        {
            Client = _fixture.Clients[0],
            Trainer = _fixture.Trainers[0],
            Hall = busyHall,
            DateTime = checkTime.AddMinutes(-30),
            IsTrial = false
        };

        List<Booking> bookingsList = [.._fixture.Bookings, overlappingBooking];
        //Act
        var result = bookingsList
            .Where(b => b.DateTime < checkTime  + Booking.Duration && 
                        checkTime  < b.DateTime + Booking.Duration)
            .Select(h => h.Hall)
            .ToList();
        //Assert
        Assert.NotEmpty(result);
        Assert.Contains(busyHall, result);
    }
    [Fact]
    //Вывести информацию о занятиях за текущий месяц, проходящих в выбранном зале.
    public void SessionsInTheChosenHall_ShouldBeFilteredByCurrentMonth()
    {
        //Arrange
        var checkDate = DateOnly.FromDateTime(_checkTime.Date);
        var chosenHall = _fixture.Halls[0];
        //Act
        var result = _fixture.Bookings
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
}