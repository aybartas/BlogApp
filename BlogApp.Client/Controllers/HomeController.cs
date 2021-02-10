using BlogApp.Client.APIServices.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBlogApiService blogApiService;


        public HomeController(IBlogApiService blogApiService)
        {
            this.blogApiService = blogApiService;
        }

        public async Task<IActionResult> Index()
        {

            var blogs = await blogApiService.GetAll();

            return View(blogs);
        }
    }
}
