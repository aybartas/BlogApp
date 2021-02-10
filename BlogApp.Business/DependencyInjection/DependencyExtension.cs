using BlogApp.Business.Concrete;
using BlogApp.Business.Interfaces;
using BlogApp.DataAccess.Concrete.Repositories;
using BlogApp.DataAccess.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.Business.DependencyInjection
{
    public static class DependencyExtension
    {
        // add DI to business because UI shouldn't be connected with DataAccess

        public static void AddDependencies (this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericDal<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));


            services.AddScoped<IBlogDal, BlogRepository>();
            services.AddScoped<IBlogService,BlogService>();

            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICategoryDal, CategoryRepository>();


            services.AddScoped<IAppUserService, AppUserService>();
 

            services.AddScoped<ICommentService, CommentService>();
            



        }
    }
}
