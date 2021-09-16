using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhlndShop.API.JWT
{
    public class JwtConfig
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Subject { get; set; }
        public int TimeExpires { get; set; }
    }
}
