using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace WebApplication
{
    public class ClaimsTransformer : IClaimsTransformation
    {
        public const string IsAdminKey = "IsAdmin";

        public Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            var identity = (ClaimsIdentity) principal.Identity;

            var claimsIdentity = new ClaimsIdentity(
                identity.Claims,
                identity.AuthenticationType,
                identity.NameClaimType,
                identity.RoleClaimType);


            claimsIdentity.AddClaim(
                new Claim(IsAdminKey, "So say we all"));
            claimsIdentity.AddClaim(new Claim(
                claimsIdentity.RoleClaimType,"Administrator"));

            return Task.FromResult(new ClaimsPrincipal(claimsIdentity));
        }
    }
}
