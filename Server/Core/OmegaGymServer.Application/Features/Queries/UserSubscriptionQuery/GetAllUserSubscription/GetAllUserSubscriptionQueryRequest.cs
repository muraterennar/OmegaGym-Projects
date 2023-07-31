using System;
using MediatR;

namespace OmegaGymServer.Application.Features.Queries.UserSubscriptionQuery.GetAllUserSubscription
{
    public class GetAllUserSubscriptionQueryRequest : IRequest<List<GetAllUserSubscriptionQueryResponse>>
    {

    }
}

