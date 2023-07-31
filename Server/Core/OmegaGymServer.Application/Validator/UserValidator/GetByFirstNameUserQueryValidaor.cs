using FluentValidation;
using OmegaGymServer.Application.Features.Queries.UserQuery.GetByFirstnameUserQuery;

namespace OmegaGymServer.Application.Validator.UserValidator;

public class GetByFirstNameUserQueryValidaor : AbstractValidator<GetByFirstnameUserQueryRequest>
{
    public GetByFirstNameUserQueryValidaor()
    {
        RuleFor(u => u.FirstName).NotNull().MinimumLength(4).MaximumLength(20);
    }
}

