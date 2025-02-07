using FluentValidation.TestHelper;
using KoperasiTenteraApi.Application.Authentication.Commands.CreateUser;
using KoperasiTenteraApi.Application.Authentication.Queries.GetByIC;
using KoperasiTenteraApi.Tests.Generators;
using NUnit.Framework;

[TestFixture]
public class GetByICValidatorTests
{
    private GetByICValidator _validator;

    [SetUp]
    public void Setup()
    {
        _validator = new GetByICValidator();
    }

    [Test]
    public void Should_Not_Have_Error()
    {
        // Arrange
        var model = Generator.GetByICQuery.Generate();

        // Act & Assert
        var result = _validator.TestValidate(model);
        result.ShouldNotHaveAnyValidationErrors();
    }

    [Test]
    public void Should_Have_Errors()
    {
        // Arrange
        var model = Generator.GetByICQuery
            .WithInvalidData()
            .Generate();

        // Act & Assert
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.IC);
    }
}