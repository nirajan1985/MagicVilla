using System.Security.Claims;

namespace System
{
    internal class ClaimsIdentity : Security.Claims.ClaimsIdentity
    {
        public ClaimsIdentity(IEnumerable<Claim>? claims) : base(claims)
        {
        }
    }
}