using AutoMapper;
using BlogApp.Business.Interfaces;
using BlogApp.Entities.Concrete;
using BlogApp.Entities.DTO.BlogDTO;
using BlogApp.WebAPI.Common.Enums;
using BlogApp.WebAPI.ViewModels.BlogViewModels;
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
    public class BlogsController : BaseController
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
            var blogs = mapper.Map<List<BlogListDTO>>(await blogService.GetBlogsSortedByPublishedTime());

            return Ok(blogs);  //201
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var blog = mapper.Map<Blog>(await blogService.FindById(id));

            return Ok(blog);

        }

        [HttpPost]
        [DisableRequestSizeLimit]

        public async Task<IActionResult> Create([FromForm] BlogCreateViewModel blogModel)
        {

            var uploadedModel = await UploadFile(blogModel.ImageFile, "image/jpeg");

            if(uploadedModel.UploadStatus == UploadStatus.Successful)
            {
                blogModel.BlogImage = uploadedModel.NewName;
                await blogService.Create(mapper.Map<Blog>(blogModel));
                return Created("", blogModel);
            }
            else if (uploadedModel.UploadStatus == UploadStatus.NotExist)
            {
                await blogService.Create(mapper.Map<Blog>(blogModel));
                
                return Created("", blogModel);
            }
            else{
                return BadRequest(uploadedModel.ErrorMessage);
            }
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromForm] BlogUpdateViewModel blogUpdateViewModel)
        {
            if (blogUpdateViewModel.Id != id) return BadRequest("Invalid blog id provided");  // 400 

            var uploadedModel = await UploadFile(blogUpdateViewModel.ImageFile, "image/jpeg");

            if (uploadedModel.UploadStatus == UploadStatus.Successful)
            {
                var blogToUpdate = await blogService.FindById(id);

                blogToUpdate.BlogImage = uploadedModel.NewName;
                blogToUpdate.Definition = blogUpdateViewModel.Definition;
                blogToUpdate.Description = blogUpdateViewModel.Description;
                blogToUpdate.Title = blogUpdateViewModel.Title;

                await blogService.Update(blogToUpdate);
                 
                return NoContent(); //  204
            }
            else if (uploadedModel.UploadStatus == UploadStatus.NotExist)
            {
                var blogToUpdate = await blogService.FindById(id);

                blogToUpdate.Definition = blogUpdateViewModel.Definition;
                blogToUpdate.Description = blogUpdateViewModel.Description;
                blogToUpdate.Title = blogUpdateViewModel.Title;

                await blogService.Update(blogToUpdate);
                return NoContent(); 
            }
            else
            {
                return BadRequest(uploadedModel.ErrorMessage);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

             await blogService.Delete(new Blog { Id = id });

            return NoContent(); 
        }


    }
}
