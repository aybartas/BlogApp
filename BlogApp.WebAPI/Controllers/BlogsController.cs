using AutoMapper;
using BlogApp.Business.Interfaces;
using BlogApp.Entities.Concrete;
using BlogApp.Entities.DTO.BlogDTO;
using BlogApp.WebAPI.ViewModels.BlogViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly IBlogService blogService;

        private readonly IMapper mapper;

        public BlogsController(IBlogService blogService, IMapper mapper)
        {
            this.blogService = blogService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var blogs =  mapper.Map<List<BlogListDTO>>(await blogService.GetBlogsSortedByPublishedTime());

            return Ok(blogs);  //201
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var blog = mapper.Map<Blog>(await blogService.FindById(id));

            return Ok(blog);
       
        }

        [HttpPost]
        public async Task<IActionResult> Create(BlogCreateViewModel blogModel)
        {

            await blogService.Create(mapper.Map<Blog>(blogModel));

            return Created("", blogModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id,BlogUpdateViewModel blogUpdateViewModel)
        {
            if (blogUpdateViewModel.Id != id) return BadRequest("Invalid blog id provided");  // 400 

            await blogService.Update(mapper.Map<Blog>(blogUpdateViewModel));

            return NoContent(); // 204
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

             await blogService.Delete(new Blog { Id = id });

            return NoContent(); 
        }


    }
}
