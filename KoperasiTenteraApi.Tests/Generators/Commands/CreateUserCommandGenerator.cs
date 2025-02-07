using Bogus;
using KoperasiTenteraApi.Application.Authentication.Commands.CreateUser;
using KoperasiTenteraApi.Domain.Shared;

namespace KoperasiTenteraApi.Tests.Generators.Commands
{
    public class CreateUserCommandGenerator : Faker<CreateUserCommand>
    {
        public CreateUserCommandGenerator()
        {
            RuleFor(x => x.IC, f => f.Random.Number(100000, 999999).ToString().PadLeft(Constants.ICLength, '0'));
            RuleFor(x => x.Name, f => f.Lorem.Word());
            RuleFor(x => x.MobileNumber, f => f.Random.Long(100000000000, 999999999999).ToString());
            RuleFor(x => x.Email, f => f.Internet.Email());
        }

        public CreateUserCommandGenerator WithInvalidData()
        {
            RuleFor(x => x.IC, f => f.Random.Number(100000, 999999).ToString());
            RuleFor(x => x.Name, f => f.Random.Number(100000, 999999).ToString());
            RuleFor(x => x.MobileNumber, f => f.Random.Long(1000, 9999).ToString());
            RuleFor(x => x.Email, f => f.Lorem.Word());

            return this;
        }
    }
}
