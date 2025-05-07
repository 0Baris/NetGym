using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Core.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static List<string> Claims(this ClaimsPrincipal claimsPrincipal, string claimType)
        {
            var result = claimsPrincipal?.FindAll(claimType)?.Select(x => x.Value).ToList();
            return result;
        }

        public static List<string> ClaimRoles(this ClaimsPrincipal claimsPrincipal)
        {
            var roleClaims = claimsPrincipal?.FindAll("http://schemas.microsoft.com/ws/2008/06/identity/claims/role");
            return roleClaims?.Select(c => c.Value).ToList() ?? new List<string>();
        }
    }
}