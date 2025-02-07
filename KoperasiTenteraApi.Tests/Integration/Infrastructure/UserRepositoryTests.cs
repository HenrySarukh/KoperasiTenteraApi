using KoperasiTenteraApi.Domain.Enums;
using KoperasiTenteraApi.Infrastructure.Persistance;
using KoperasiTenteraApi.Infrastructure.Persistance.Repositories;
using KoperasiTenteraApi.Tests.Base;
using KoperasiTenteraApi.Tests.Generators;
using NUnit.Framework;

namespace KoperasiTenteraApi.Tests.Integration.Infrastructure
{
    public class UserRepositoryTests : IntegrationBase
    {
        private readonly UserRepository _repository;

        public UserRepositoryTests()
        {
            _repository = new(KoperasiTenteraContext);
        }

        [Test]
        public async Task GetByIC_ReturnsUser_WhenICExists()
        {
            // Arrange
            var user = Generator.User.Generate();
            user.Id = 0;
            await KoperasiTenteraContext.Users.AddAsync(user);
            await KoperasiTenteraContext.SaveChangesAsync();

            // Act
            var result = await _repository.GetByIC(user.IC);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(user.Name, result.Name);
            Assert.AreEqual(user.IC, result.IC);
        }

        [Test]
        public async Task GetByIC_ReturnsNull_WhenICDoesNotExist()
        {
            // Arrange
            var user = Generator.User.Generate();

            // Act
            var result = await _repository.GetByIC(user.IC);

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public async Task GetByOtpSource_ReturnsUser_WhenPhoneOtpTypeMatches()
        {
            // Arrange
            var user = Generator.User.Generate();
            user.Id = 0;
            await KoperasiTenteraContext.Users.AddAsync(user);
            await KoperasiTenteraContext.SaveChangesAsync();

            var otpType = OtpType.Phone;

            // Act
            var result = await _repository.GetByOtpSource(otpType, user.MobileNumber);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(user.MobileNumber, result.MobileNumber);
            Assert.AreEqual(user.Name, result.Name);
        }

        [Test]
        public async Task GetByOtpSource_ReturnsNull_WhenPhoneOtpTypeDoesNotMatch()
        {
            // Arrange
            var user = Generator.User.Generate();
            var otpType = OtpType.Phone;

            // Act
            var result = await _repository.GetByOtpSource(otpType, user.MobileNumber);

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public async Task GetByOtpSource_ReturnsUser_WhenEmailOtpTypeMatches()
        {
            // Arrange
            var user = Generator.User.Generate();
            user.Id = 0;
            await KoperasiTenteraContext.Users.AddAsync(user);
            await KoperasiTenteraContext.SaveChangesAsync();

            var otpType = OtpType.Email;

            // Act
            var result = await _repository.GetByOtpSource(otpType, user.Email);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(user.Email, result.Email);
            Assert.AreEqual(user.Name, result.Name);
        }

        [Test]
        public async Task GetByOtpSource_ReturnsNull_WhenEmailOtpTypeDoesNotMatch()
        {
            // Arrange
            var user = Generator.User.Generate();
            var otpType = OtpType.Email;

            // Act
            var result = await _repository.GetByOtpSource(otpType, user.Email);

            // Assert
            Assert.IsNull(result);
        }
    }
}
