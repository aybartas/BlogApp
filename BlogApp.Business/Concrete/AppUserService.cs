using BlogApp.Business.Interfaces;
using BlogApp.DataAccess.Interfaces;
using BlogApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.Business.Concrete
{
   public class AppUserService : GenericService<AppUser>,IAppUserService
    {

        private readonly IGenericDal<AppUser> genericDal;

        public AppUserService(IGenericDal<AppUser> genericDal): base(genericDal)
        {
            this.genericDal = genericDal;
        }
    }
}
