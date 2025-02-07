using ErrorOr;
using KoperasiTenteraApi.Application.Authentication.Queries;
using KoperasiTenteraApi.Application.Contracts;
using KoperasiTenteraApi.Domain.Contracts;
using KoperasiTenteraApi.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoperasiTenteraApi.Application.Authentication.Commands.CreateUser
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, ErrorOr<bool>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IOtpService _otpService;

        public CreateUserHandler(IUserRepository userRepository, IOtpService otpService)
        {
            _userRepository = userRepository;
            _otpService = otpService;
        }

        public async Task<ErrorOr<bool>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIC(request.IC);
            if (user != null)
            {
                return Error.Conflict(description: "User Already Exists!");
            }

            var createdUser = await _userRepository.Add(new Domain.Entities.User
            {
                IC = request.IC,
                MobileNumber = request.MobileNumber,
                Email = request.Email,
                Name = request.Name
            });

            await _otpService.SendOtp(OtpType.Phone, createdUser.MobileNumber);
            return true;
        }
    }
}
