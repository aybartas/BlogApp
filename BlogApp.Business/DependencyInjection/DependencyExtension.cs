using BlogApp.Business.Concrete;
using BlogApp.Business.Interfaces;
using BlogApp.Business.Utility.AuthUtility;
using BlogApp.Business.Validation;
using BlogApp.DataAccess.Concrete.Repositories;
using BlogApp.DataAccess.Interfaces;
using BlogApp.Entities.DTO.BlogDTO;
using BlogApp.Entities.DTO.CategoryDTO;
using BlogApp.Entities.DTO.UserDTO;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.Business.DependencyInjection
{
    public static class DependencyExtension
    {
        // Extension method to DI services 
        // add DI to business because UI shouldn't be connected with DataAccess
     
        public static void AddDependencies (this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericDal<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));

            // Blogs
            services.AddScoped<IBlogDal, BlogRepository>();
            services.AddScoped<IBlogService,BlogService>();

            //Categories
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICategoryDal, CategoryRepository>();

            // User
            services.AddScoped<IAppUserService, AppUserService>();
            services.AddScoped<IAppUserDal, AppUserRepository>();

            // Comments
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<ICommentDal, CommentRepository>();

            // JWT 
            services.AddScoped<IJwtService, JwtService>();

            services.AddTransient<IValidator<UserLoginDTO>, UserLoginValidator>();
            services.AddTransient<IValidator<CategoryCreateDTO>, CategoryCreateValidator>();
            services.AddTransient<IValidator<BlogCategoryDto>, BlogCategoryValidator>();
            services.AddTransient<IValidator<CategoryUpdateDTO>, CategoryUpdateValidator>();




        }
    }
}
