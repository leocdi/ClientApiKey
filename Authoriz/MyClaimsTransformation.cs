using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

public class MyClaimsTransformation : IClaimsTransformation
{

    public Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
    {
        ClaimsIdentity claimsIdentity = new ClaimsIdentity();
        var claimType = "myNewClaim";
        if (!principal.HasClaim(claim => claim.Type == claimType))
        {
            claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, "Admin"));
        }

        principal.AddIdentity(claimsIdentity);
        return Task.FromResult(principal);
    }

}