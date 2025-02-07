using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoperasiTenteraApi.Application.Authentication.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<ErrorOr<bool>>
    {
        public required string IC { get; set; }
        public required string Name { get; set; }
        public required string MobileNumber { get; set; }
        public required string Email { get; set; }
    }
}
