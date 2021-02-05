using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.Entities.DTO.BlogDTO
{
    public class BlogListDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Definition { get; set; }
        public string Description { get; set; }
        public DateTime PublishedTime { get; set; } 
        public string BlogImage { get; set; }

    }
}
