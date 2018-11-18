using System;
using System.Security.Principal;

namespace KP.Infrastructure.Extensions
{
    public static class IdentityExtensions
    {
        public static string GetDomain(this IIdentity identity)
        {
            var s = identity.Name;
            var stop = s.IndexOf("\\", StringComparison.Ordinal);
            return stop > -1 ? s.Substring(0, stop) : string.Empty;
        }

        public static string GetLogin(this IIdentity identity)
        {
            var s = identity.Name;
            var stop = s.IndexOf("\\", StringComparison.Ordinal);
            return stop > -1 ? s.Substring(stop + 1, s.Length - stop - 1) : string.Empty;
        }
    }
}
