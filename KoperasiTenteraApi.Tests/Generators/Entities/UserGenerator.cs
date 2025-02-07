using Bogus;
using KoperasiTenteraApi.Application.Authentication.Commands.ValidateOtp;
using KoperasiTenteraApi.Domain.Entities;
using KoperasiTenteraApi.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoperasiTenteraApi.Tests.Generators.Entities
{
    public class UserGenerator : Faker<User>
    {
        public UserGenerator()
        {
            RuleFor(x => x.Id, f => 1);
            RuleFor(x => x.IC, f => f.Random.Number(100000, 999999).ToString().PadLeft(Constants.ICLength, '0'));
            RuleFor(x => x.Name, f => f.Lorem.Word());
            RuleFor(x => x.MobileNumber, f => f.Random.Long(100000000000, 999999999999).ToString());
            RuleFor(x => x.Email, f => f.Internet.Email());
        }
    }
}
