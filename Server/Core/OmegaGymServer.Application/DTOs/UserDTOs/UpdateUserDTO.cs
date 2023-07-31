﻿namespace OmegaGymServer.Application.DTOs.UserDTOs;

public class UpdateUserDTO
{
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Gender { get; set; }

    public Guid OperationClaimId { get; set; }
}

