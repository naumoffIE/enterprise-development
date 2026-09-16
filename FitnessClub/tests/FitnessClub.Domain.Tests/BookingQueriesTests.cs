// using FitnessClub.Domain;

namespace FitnessClub.Domain.Tests;

public class BookingQueriesTests
{
    [Fact]
    public void ExperiencedTrainers_ShouldHaveAtLeast5YearsExperience()
    {
        // Arrange
        //Act
        var result = TestData.Trainers.Where(t => t.Experience >= 5).ToList();
        //Assert
        Assert.NotEmpty(result);
        Assert.All(result, t => Assert.True(t.Experience >= 5));
    }
    [Fact]
    public void ClientsWithOverdueSubscriptions_ShouldBeOrderedByFullName()
    {
        //Arrange
        var today = DateOnly.FromDateTime(DateTime.Now);
        //Act
        var result = TestData.Clients
            .Where(c => c.SubscriptionEnd < today)
            .OrderBy(c => c.FullName)
            .ToList();
        //Assert
        Assert.NotEmpty(result);
        Assert.All(result, c => Assert.True(c.SubscriptionEnd < today));
    }
    [Fact]
    public void MostPopularTrainers_ShouldBeOrderedByNumberOfBookings()
    {
        //Arrange
        //Act

    }


}