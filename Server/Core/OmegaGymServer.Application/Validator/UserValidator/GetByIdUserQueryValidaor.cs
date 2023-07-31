using FluentValidation;
using OmegaGymServer.Application.Features.Queries.UserQuery.GetByIdUserQuery;

namespace OmegaGymServer.Application.Validator.UserValidator;

public class GetByIdUserQueryValidaor : AbstractValidator<GetByIdUserQueryRequest>
{
    public GetByIdUserQueryValidaor()
    {
        RuleFor(u => u.Id).NotNull();
    }
}

