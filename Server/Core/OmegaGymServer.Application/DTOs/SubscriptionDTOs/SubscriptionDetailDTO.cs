namespace OmegaGymServer.Application.DTOs.SubscriptionDTOs;

public class SubscriptionDetailDTO
{
    public Guid SubscriptionId { get; set; }
    public Guid SubscriptionCategoryId { get; set; }

    public string SubscriptionCategoryName { get; set; }
    public string SubscriptionTitle { get; set; }
    public string SubscriptionDescription { get; set; }
    public decimal SubscriptionPrice { get; set; }

    public string SubscriptionArticlelOne { get; set; }
    public string SubscriptionArticlelTwo { get; set; }
    public string SubscriptionArticlelThree { get; set; }
}

