using FluentValidation.TestHelper;
using KoperasiTenteraApi.Application.Authentication.Commands.ValidateOtp;
using KoperasiTenteraApi.Domain.Shared;
using KoperasiTenteraApi.Tests.Generators;
using NUnit.Framework;

[TestFixture]
public class ValidateOtpValidatorTests
{
    private ValidateOtpValidator _validator;

    [SetUp]
    public void Setup()
    {
        _validator = new ValidateOtpValidator();
    }

    [Test]
    public void Should_Not_Have_Error()
    {
        // Arrange
        var model = Generator.ValidateOtp.Generate();

        if (model.OtpType == KoperasiTenteraApi.Domain.Enums.OtpType.Email)
        {
            model.Source = "henry.sarukhany2001@gmail.com";
        }
        else
        {
            model.Source = "123412341234";
        }

        // Act & Assert
        var result = _validator.TestValidate(model);
        result.ShouldNotHaveAnyValidationErrors();
    }

    [Test]
    public void Should_Have_Errors()
    {
        // Arrange
        var model = Generator.ValidateOtp
            .WithInvalidData()
            .Generate();

        // Act & Assert
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.Code);
        result.ShouldHaveValidationErrorFor(x => x.OtpType);
    }
}