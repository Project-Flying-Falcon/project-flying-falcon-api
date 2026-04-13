using Microsoft.VisualStudio.TestTools.UnitTesting;
using Flying.Falcon.Domain.Catalog;

namespace project_flying_falcon.Domain.Tests;

[TestClass]
public sealed class RatingTests
{
    [TestMethod]
    public void Can_Create_New_Rating()
    {
        // Arrange
        var rating = new Rating(1, "Mike", "Great fit!");

        // Act (empty)

        // Assert
        Assert.AreEqual(1, rating.Stars);
        Assert.AreEqual("Mike", rating.UserName);
        Assert.AreEqual("Great fit!", rating.Review);
    }

    [TestMethod]
    public void Cannot_Create_Rating_With_Invalid_Stars()
    {
        // Arrange & Assert
        try
        {
            var rating = new Rating(0, "Mike", "Great fit!");
            Assert.Fail("Expected ArgumentException was not thrown");
        }
        catch (ArgumentException)
        {
            // Test passes
        }
    }
}