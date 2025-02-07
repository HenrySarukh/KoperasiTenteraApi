using KoperasiTenteraApi.Tests.Generators.Commands;
using KoperasiTenteraApi.Tests.Generators.Entities;
using KoperasiTenteraApi.Tests.Generators.Queries;

namespace KoperasiTenteraApi.Tests.Generators
{
    public static class Generator
    {
        public static GetByICQueryGenerator GetByICQuery => new();
        public static CreateUserCommandGenerator CreateUserCommand => new();
        public static ValidateOtpCommandGenerator ValidateOtp => new();
        public static UserGenerator User => new();
    }
}
