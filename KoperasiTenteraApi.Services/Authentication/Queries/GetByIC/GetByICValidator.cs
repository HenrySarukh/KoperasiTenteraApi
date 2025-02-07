using FluentValidation;
using KoperasiTenteraApi.Domain.Shared;

namespace KoperasiTenteraApi.Application.Authentication.Queries.GetByIC
{
    public class GetByICValidator : AbstractValidator<GetByICQuery>
    {
        public GetByICValidator()
        {
            RuleFor(x => x.IC)
                .Length(Constants.ICLength)
                    .WithMessage($"IC must be {Constants.ICLength} characters long.")
                .Matches(@"^\d+$")
                    .WithMessage("IC must be a number.");
        }
    }
}
