using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.Entities.DTO.CategoryDTO
{
    public class CategoryListDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentCategoryId { get; set; }

        
    }
}
