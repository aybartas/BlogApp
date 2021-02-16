using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.Business.JwtConfig
{
    public static class JwtConfig
    {
        // iis setings
        public const string Issuer = "http://localhost:52624"; 
        // client appUrl

        public const string Audience = "http://localhost:5000";

        public const string SecurityKey = "itsmysecuritykeyitsmysecuritykeyitsmysecuritykeyitsmysecuritykey";

        public const double Expires = 60;

    }
}
