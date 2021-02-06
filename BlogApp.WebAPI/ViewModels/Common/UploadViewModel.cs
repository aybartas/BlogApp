using BlogApp.WebAPI.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.WebAPI.ViewModels.Common
{
    public class UploadViewModel
    {
        public string NewName { get; set; }
        public string ErrorMessage { get; set; }
        public UploadStatus UploadStatus { get; set; }
    }
}
