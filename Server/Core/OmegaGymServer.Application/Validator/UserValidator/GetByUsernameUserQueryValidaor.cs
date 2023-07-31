using FluentValidation;
using OmegaGymServer.Application.Features.Queries.UserQuery.GetByUsernameUserQuery;

namespace OmegaGymServer.Application.Validator.UserValidator;

public class GetByUsernameUserQueryValidaor : AbstractValidator<GetByUsernameUserQueryRequest>
{
    public GetByUsernameUserQueryValidaor()
    {
        RuleFor(u => u.UserName).NotNull().MinimumLength(3).MaximumLength(20);
    }
}

