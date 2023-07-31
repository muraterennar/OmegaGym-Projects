using System;
using OmegaGymServer.Domain.Entities;

namespace OmegaGymServer.Application.Features.Queries.UserSubscriptionQuery.GetAllUserSubscription
{
    public class GetAllUserSubscriptionQueryResponse
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public Guid UserId { get; set; }
        public Guid SubscriptionId { get; set; }
    }
}

