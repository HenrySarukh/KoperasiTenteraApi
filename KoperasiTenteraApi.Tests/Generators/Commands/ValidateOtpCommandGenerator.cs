using Bogus;
using KoperasiTenteraApi.Application.Authentication.Commands.CreateUser;
using KoperasiTenteraApi.Application.Authentication.Commands.ValidateOtp;
using KoperasiTenteraApi.Domain.Enums;
using KoperasiTenteraApi.Domain.Shared;
using KoperasiTenteraApi.Tests.Generators.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoperasiTenteraApi.Tests.Generators.Commands
{
    public class ValidateOtpCommandGenerator : Faker<ValidateOtpCommand>
    {
        public ValidateOtpCommandGenerator()
        {
            RuleFor(x => x.OtpType, f => f.PickRandom<OtpType>());
            RuleFor(x => x.Code, f => f.Random.Number(100000, 999999).ToString().PadLeft(Constants.OtpLength, '0'));
        }

        public ValidateOtpCommandGenerator WithInvalidData()
        {
            RuleFor(x => x.OtpType, f => (OtpType)f.Random.Number(3,10));
            RuleFor(x => x.Code, f => f.Random.Number(100000, 999999).ToString().PadLeft(Constants.OtpLength + 1, '0'));
            RuleFor(x => x.Source, f => f.Lorem.Word());

            return this;
        }
    }
}
