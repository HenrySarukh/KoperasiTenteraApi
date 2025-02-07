using FluentValidation;
using KoperasiTenteraApi.Application.Authentication.Queries;
using KoperasiTenteraApi.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoperasiTenteraApi.Application.Authentication.Commands.CreateUser
{
    public class CreateUserValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserValidator()
        {
            RuleFor(x => x.IC)
                .Length(Constants.ICLength)
                    .WithMessage($"IC must be {Constants.ICLength} characters long.")
                .Matches(@"^\d+$")
                    .WithMessage("IC must be a number.");
            RuleFor(x => x.Email)
                .EmailAddress()
                    .WithMessage("Please provide a valid email address.");
            RuleFor(x => x.MobileNumber)
                .Matches(@"^\d{12}$")  // Assuming a 12 characters mobile number format (adjust as needed)
                    .WithMessage("Mobile number must be 10 digits long and contain only numbers.");
            RuleFor(x => x.Name)
               .Length(3, 20)
                    .WithMessage("Name must be between 3 and 20 characters long.")
               .Matches(@"^[a-zA-Z\s]+$")
                    .WithMessage("Name must only contain letters and spaces.");
        }

    }
}
