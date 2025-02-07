using ErrorOr;
using KoperasiTenteraApi.Application.Contracts;
using KoperasiTenteraApi.Domain.Contracts;
using KoperasiTenteraApi.Domain.Entities;
using KoperasiTenteraApi.Domain.Enums;
using KoperasiTenteraApi.Domain.Exceptions;
using MediatR;

namespace KoperasiTenteraApi.Application.Authentication.Queries.GetByIC
{
    public class GetByICHandler : IRequestHandler<GetByICQuery, ErrorOr<bool>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IOtpService _otpService;

        public GetByICHandler(IUserRepository userRepository, IOtpService otpService)
        {
            _userRepository = userRepository;
            _otpService = otpService;
        }

        public async Task<ErrorOr<bool>> Handle(GetByICQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIC(request.IC);
            if (user == null)
            {
                return Error.NotFound(description: "User Not Found");
            }

            await _otpService.SendOtp(OtpType.Phone, user.MobileNumber);
            return true;
        }
    }
}
