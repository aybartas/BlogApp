using BlogApp.Business.Interfaces;
using BlogApp.DataAccess.Interfaces;
using BlogApp.Entities.Concrete;
using BlogApp.Entities.DTO.UserDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.Concrete
{
   public class AppUserService : GenericService<AppUser>,IAppUserService
    {

        private readonly IGenericDal<AppUser> genericDal;

        public AppUserService(IGenericDal<AppUser> genericDal): base(genericDal)
        {
            this.genericDal = genericDal;
        }

        public async Task<AppUser>  CheckOutUser(UserLoginDTO userLoginDTO)
        {
            var user = await genericDal.GetByFilter(
                I => I.Username.Equals(userLoginDTO.Username)
                && I.Password.Equals(userLoginDTO.Password));

            return user;
        }

        public async Task<AppUser> FindByUsername(string username)
        {
            var user = await genericDal.GetByFilter(
                I => I.Username.Equals(username));

            return user;
        }
    }
}
