using BlogApp.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.Entities.Concrete
{
   public class Category: ITable
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public int? ParentCategoryId { get; set; }
        public List<BlogCategory> BlogCategories { get; set; }
        public Category ParentCategory { get; set; }
        public List<Category> SubCategories { get; set; }
    }
}
