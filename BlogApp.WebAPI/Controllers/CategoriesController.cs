using AutoMapper;
using BlogApp.Business.Interfaces;
using BlogApp.Entities.Concrete;
using BlogApp.Entities.DTO.CategoryDTO;
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
    public class CategoriesController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ICategoryService categoryService;

        public CategoriesController(IMapper mapper, ICategoryService categoryService)
        {
            this.mapper = mapper;
            this.categoryService = categoryService;

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories =  await categoryService.GetAll();
            return Ok(mapper.Map<List<CategoryListDTO>>(categories));
        }


        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await categoryService.GetByFilter(I => I.Id == id);

            return Ok(mapper.Map<CategoryListDTO>(category));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryCreateDTO categoryCreateDTO)
        {
             await categoryService.Create(mapper.Map<Category>(categoryCreateDTO));

            return Created("", categoryCreateDTO);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id ,CategoryCreateDTO categoryCreateDTO)
        {
            if (id != categoryCreateDTO.Id) return BadRequest("Category to update doesn't exist in database");
            await categoryService.Update(mapper.Map<Category>(categoryCreateDTO));
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            var categoryToDelete = await categoryService.FindById(id);

            if (categoryToDelete == null) return BadRequest("The cagetory to be deleted doesn't exist in database");

            await categoryService.Delete(new Category { Id = id });

            return NoContent();
        }
    }
}
