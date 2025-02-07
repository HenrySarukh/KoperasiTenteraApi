using AutoMapper;
using ErrorOr;
using KoperasiTenteraApi.Application.Contracts;
using KoperasiTenteraApi.Application.Dtos;
using KoperasiTenteraApi.Domain.Contracts;
using KoperasiTenteraApi.Domain.Enums;
using MediatR;

namespace KoperasiTenteraApi.Application.Authentication.Commands.ValidateOtp
{
    public class ValidateOtpHandler : IRequestHandler<ValidateOtpCommand, ErrorOr<UserDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IOtpService _otpService;
        private readonly IMapper _mapper;

        public ValidateOtpHandler(
            IUserRepository userRepository,
            IOtpService otpService,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _otpService = otpService;
            _mapper = mapper;
        }

        public async Task<ErrorOr<UserDto>> Handle(ValidateOtpCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByOtpSource(request.OtpType, request.Source);
            if (user == null)
            {
                var source = request.OtpType == OtpType.Phone ? "phone" : "email";
                return Error.NotFound(description: $"User with given {source} not found");
            }

            var isOtpValid = await _otpService.CheckOtp(request.OtpType, request.Source, request.Code);
            if (!isOtpValid)
            {
                // OR Custom error
                return Error.NotFound(description: "Otp is not valid");
            }

            if (request.OtpType == OtpType.Phone)
            {
                await _otpService.SendOtp(OtpType.Email, user.Email);
                return _mapper.Map<UserDto>(null);
            }

            // I will prefer to send Auth Token, but it is company based.
            return _mapper.Map<UserDto>(user);
        }
    }
}
