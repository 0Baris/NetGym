using System;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Core.Utilities.Security.Encryption
{
    public class SecurityKeyHelper
    {
        public static SecurityKey CreateSecurityKey(string securityKey)
        {
            if (Encoding.UTF8.GetBytes(securityKey).Length < 64)
            {
                throw new ArgumentException("Security key must be at least 64 characters long.");
            }
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
        }

    }
}