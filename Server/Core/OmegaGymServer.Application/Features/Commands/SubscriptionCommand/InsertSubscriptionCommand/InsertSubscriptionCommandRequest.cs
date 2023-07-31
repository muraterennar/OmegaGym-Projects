using MediatR;
using OmegaGymServer.Domain.Entities;

namespace OmegaGymServer.Application.Features.Commands.SubscriptionCommand.InsertSubscriptionCommand;

public class InsertSubscriptionCommandRequest : IRequest<InsertSubscriptionCommandResponse>
{
    public string SubscriptionTitle { get; set; }
    public string SubscriptionDescription { get; set; }
    public decimal SubscriptionPrice { get; set; }

    public string SubscriptionArticlelOne { get; set; }
    public string SubscriptionArticlelTwo { get; set; }
    public string SubscriptionArticlelThree { get; set; }

    public Guid SubscriptionCategoryId { get; set; }
}

