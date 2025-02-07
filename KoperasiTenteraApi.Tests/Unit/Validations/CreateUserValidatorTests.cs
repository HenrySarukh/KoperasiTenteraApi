using FluentValidation.TestHelper;
using KoperasiTenteraApi.Application.Authentication.Commands.CreateUser;
using KoperasiTenteraApi.Tests.Generators;
using NUnit.Framework;

[TestFixture]
public class CreateUserCommandValidatorTests
{
    private CreateUserValidator _validator;

    [SetUp]
    public void Setup()
    {
        _validator = new CreateUserValidator();
    }

    [Test]
    public void Should_Not_Have_Error()
    {
        // Arrange
        var model = Generator.CreateUserCommand.Generate();

        // Act & Assert
        var result = _validator.TestValidate(model);
        result.ShouldNotHaveAnyValidationErrors();
    }

    [Test]
    public void Should_Have_Errors()
    {
        // Arrange
        var model = Generator.CreateUserCommand
            .WithInvalidData()
            .Generate();

        // Act & Assert
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.Name);
        result.ShouldHaveValidationErrorFor(x => x.IC);
        result.ShouldHaveValidationErrorFor(x => x.Email);
        result.ShouldHaveValidationErrorFor(x => x.Name);
    }
}