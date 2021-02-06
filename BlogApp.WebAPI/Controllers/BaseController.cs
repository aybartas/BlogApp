using BlogApp.WebAPI.ViewModels.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {

        public async Task<UploadViewModel>  UploadFile(IFormFile file, string fileType)
        {

            if (file == null) return new UploadViewModel { ErrorMessage = "File not exist", UploadStatus = Common.Enums.UploadStatus.NotExist };

            if (file.ContentType != fileType)
            {
                return new UploadViewModel {
                    ErrorMessage = "Only files with jpeg extension are supported",
                    UploadStatus = Common.Enums.UploadStatus.ErrorOccured
                };
            }

            else
            {
                var uniqueBlogName = Guid.NewGuid() + Path.GetExtension(file.FileName);

                var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/" + uniqueBlogName);

                var stream = new FileStream(imagePath, FileMode.Create);

                await file.CopyToAsync(stream);
                     
                return new UploadViewModel{ NewName = uniqueBlogName,UploadStatus = Common.Enums.UploadStatus.Successful};
            }  
        }
    }
}
