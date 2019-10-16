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

            // create a new ClaimsIdentity copying the existing one
            var claimsIdentity = new ClaimsIdentity(
                identity.Claims,
                identity.AuthenticationType,
                identity.NameClaimType,
                identity.RoleClaimType);

            // check if our user is in the admin table
            // identity.Name is the domain-prefixed id, eg HOME\philip

            claimsIdentity.AddClaim(
                new Claim(IsAdminKey, "So say we all"));
            claimsIdentity.AddClaim(new Claim(
                claimsIdentity.RoleClaimType,"Administrator"));


            // create a new ClaimsPrincipal in observation
            // of the documentation note
            return Task.FromResult(new ClaimsPrincipal(claimsIdentity));
        }
    }
}