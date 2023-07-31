using System;
using MediatR;

namespace OmegaGymServer.Application.Features.Queries.UserQuery.GetByUsernameUserQuery
{
    public class GetByUsernameUserQueryRequest : IRequest<GetByUsernameUserQueryResponse>
    {
        public string UserName { get; set; }
    }
}

