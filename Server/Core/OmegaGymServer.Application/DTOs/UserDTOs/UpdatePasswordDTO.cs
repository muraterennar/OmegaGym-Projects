namespace OmegaGymServer.Application.DTOs.UserDTOs;

public class UpdatePasswordDTO
{
    public string UserId { get; set; }
    public string ResetToken { get; set; }
    public string NewPassword { get; set; }
}

