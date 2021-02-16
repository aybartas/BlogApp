using BlogApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.Business.Utility.AuthUtility
{
    public interface IJwtService
    {
        Token BuildJwtToken(AppUser user);
    }
}
