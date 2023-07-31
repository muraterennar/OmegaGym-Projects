using System.Security.Claims;

namespace OmegaGymServer.Application.Extentions;

public static class ClaimPrincipalExtentions
{
    public static string Cliams(this ClaimsPrincipal claimsPrincipal, string claimType)
    {
        var result = claimsPrincipal?.FindAll(claimType)?.Select(x => x.Value);
        return result.ToString();
    }

    public static string ClaimRoles(this ClaimsPrincipal claimsPrincipal)
    {
        return claimsPrincipal?.Cliams(ClaimTypes.Role);
    }
}

