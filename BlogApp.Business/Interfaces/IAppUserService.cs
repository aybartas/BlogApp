using BlogApp.Entities.Concrete;
using BlogApp.Entities.DTO.UserDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.Interfaces
{
  public interface IAppUserService: IGenericService<AppUser>
    {

        Task<AppUser> CheckOutUser(UserLoginDTO userLoginDTO);
        Task<AppUser> FindByUsername(string username);

    }
}
