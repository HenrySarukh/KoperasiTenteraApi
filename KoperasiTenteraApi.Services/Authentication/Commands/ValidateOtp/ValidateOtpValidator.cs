using FluentValidation;
using KoperasiTenteraApi.Application.Authentication.Queries;
using KoperasiTenteraApi.Domain.Enums;
using KoperasiTenteraApi.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoperasiTenteraApi.Application.Authentication.Commands.ValidateOtp
{
    public class ValidateOtpValidator : AbstractValidator<ValidateOtpCommand>
    {
        public ValidateOtpValidator()
        {
            RuleFor(x => x.Code)
                .Length(Constants.OtpLength)
                    .WithMessage($"OTP Code must be {Constants.OtpLength} characters long.")
                .Matches(@"^\d+$")
                    .WithMessage("OTP must be a number.");
            RuleFor(x => x.OtpType).IsInEnum();
            RuleFor(x => x.Source)
                .NotNull()
                .EmailAddress()
                .When(x => x.OtpType == OtpType.Email, ApplyConditionTo.CurrentValidator)
                    .WithMessage("Please provide a valid email address.")
                .NotNull()
                .Matches(@"^\d{12}$")
                .When(x => x.OtpType == OtpType.Phone, ApplyConditionTo.CurrentValidator)
                    .WithMessage("Please provide a valid phone number.");
        }

    }
}
