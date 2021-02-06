using AutoMapper;
using BlogApp.Entities.Concrete;
using BlogApp.Entities.DTO.BlogDTO;
using BlogApp.Entities.DTO.CategoryDTO;
using BlogApp.WebAPI.ViewModels.BlogViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.WebAPI.AutoMapper
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {

            // BLOG 
            CreateMap<BlogListDTO, Blog>();
            CreateMap<Blog , BlogListDTO>();

            CreateMap<BlogCreateViewModel, Blog>();
            CreateMap<Blog, BlogCreateViewModel>();

            CreateMap<BlogUpdateViewModel, Blog>();
            CreateMap<Blog, BlogUpdateViewModel>();

            // CATEGORY 
            CreateMap<Category, CategoryCreateDTO>();
            CreateMap<CategoryCreateDTO, Category>();

            CreateMap<Category, CategoryListDTO>();
            CreateMap<CategoryListDTO, Category>();

            CreateMap<Category, CategoryUpdateDTO>();
            CreateMap<CategoryUpdateDTO, Category>();

        }
    }
}
