using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirsoftClub.Infrastructure.Data
{
    public class AuthOptions
    {
        public string Issuer { get; set; } //Кто сгенерировал токен
        public string Audience { get; set; } //Кому предназначался
        public string Secret { get; set; }
        public int TokenLifetime { get; set; } // secs
        public SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Secret));
        }
    }
}
