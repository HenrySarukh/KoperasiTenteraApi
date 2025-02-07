using ErrorOr;
using KoperasiTenteraApi.Application.Dtos;
using KoperasiTenteraApi.Domain.Entities;
using KoperasiTenteraApi.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoperasiTenteraApi.Application.Authentication.Commands.ValidateOtp
{
    public class ValidateOtpCommand : IRequest<ErrorOr<UserDto>>
    {
        public OtpType OtpType { get; set; }
        public required string Code { get; set; }
        public required string Source { get; set; }
    }
}
