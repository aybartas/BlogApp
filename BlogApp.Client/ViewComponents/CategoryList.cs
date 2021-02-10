using BlogApp.Client.APIServices.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Client.ViewComponents
{
    public class CategoryList : ViewComponent
    {
        private readonly ICategoryApiService _categoryApiService;
        public CategoryList(ICategoryApiService categoryApiService)
        {
            _categoryApiService = categoryApiService;
        }
        public IViewComponentResult Invoke()
        {
            return View(_categoryApiService.GetAll().Result);
        }
    }
}
