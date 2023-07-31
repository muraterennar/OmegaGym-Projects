namespace OmegaGymServer.Application.CustomAttributes;

[AttributeUsage(AttributeTargets.All)]
public class AuthorizeDefinationAttribute : Attribute
{
    public string[] Roles { get; set; }
}

