using inzOprogramowania.DataContext;
using inzOprogramowania.ModelDtos;
using inzOprogramowania.Modeles;
using inzOprogramowania.Repos;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace IntegralTests
{
    [TestClass]
    public class ApiTests
    {
        private DbContextOptions<DatabaseContext> _dbContextOptions;

        [TestInitialize]
        public void Initialize()
        {
            _dbContextOptions = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var dbContext = new DatabaseContext(_dbContextOptions))
            {
                // Dodaj przyk³adowe dane do testowej bazy danych
                var user = new User { UserId = 1, UserName = "John", Email = "test@wp.pl", IsActive = true, Role = "User", Password = "qwerty123!" };

                var ads = new List<Ads>
            {
                new Ads { AdsId = 1, UserId = 1, Title = "Ad 1", Description = "Description 1", ISBN = "test", CreationTime = new DateTime(), ExpiredTime = new DateTime() },
                new Ads { AdsId = 2, UserId = 1, Title = "Ad 2", Description = "Description 2",ISBN = "test", CreationTime = new DateTime(), ExpiredTime = new DateTime() },
                new Ads { AdsId = 3, UserId = 2, Title = "Ad 3", Description = "Description 3", ISBN = "test", CreationTime = new DateTime(), ExpiredTime = new DateTime() }
            };

                dbContext.Users.Add(user);
                dbContext.Ads.AddRange(ads);

                dbContext.SaveChanges();
            }
        }

        [TestCleanup]
        public void Cleanup()
        {
            using (var dbContext = new DatabaseContext(_dbContextOptions))
            {
                // Usuñ testow¹ bazê danych po zakoñczeniu testu
                dbContext.Database.EnsureDeleted();
            }
        }

        [TestMethod]
        public async Task AdsRepository_GetAllByUserId_ReturnsAdsForUser()
        {
            // Arrange
            long userId = 1; // ID u¿ytkownika do testowania

            using (var dbContext = new DatabaseContext(_dbContextOptions))
            {
                var repository = new AdsRepository(dbContext);

                // Act
                var result = await repository.GetAllByUserId(userId);

                // Assert
                Assert.AreEqual(2, result.Count);
                Assert.IsTrue(result.All(ad => ad.UserId == userId));
            }
        }
    }
}