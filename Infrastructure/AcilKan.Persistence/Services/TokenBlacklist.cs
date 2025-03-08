using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Persistence.Services
{
    public static class TokenBlacklist
    {
        private static readonly HashSet<string> _blacklistedTokens = new();

        public static void AddToBlacklist(string token)
        {
            _blacklistedTokens.Add(token);
        }

        public static bool IsTokenBlacklisted(string token)
        {
            return _blacklistedTokens.Contains(token);
        }
    }
}
