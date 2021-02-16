using BlogApp.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IBlogService blogservice;

        public ImagesController(IBlogService blogservice)
        {
            this.blogservice = blogservice;
        }

        [HttpGet("[action]/{id}")]

        public async Task<IActionResult> GetBlogImageById(int id)
        {
            var blog = await blogservice.FindById(id);

            if (string.IsNullOrWhiteSpace(blog.BlogImage))
            {
                return NotFound("There is no image to show");
            }

            return File($"/images/{blog.BlogImage}","image/jpeg");

        }
    }
}
