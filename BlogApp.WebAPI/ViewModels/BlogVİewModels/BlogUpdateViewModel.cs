using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.WebAPI.ViewModels.BlogViewModels
{
    public class BlogUpdateViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Definition { get; set; }
        public string Description { get; set; }
        public string BlogImage { get; set; }
        public int AuthorId { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}
