using BlogApp.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.Entities.Concrete
{
    public class Blog: ITable
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Definition { get; set; }
        public string Description { get; set; }
        public DateTime PublishedTime { get; set; } = DateTime.Now;
        public string BlogImage { get; set; }

        public  int AuthorId { get; set; }
        public AppUser AppUser { get; set; }

        public List<Comment> Comments { get; set; }

        public List<BlogCategory> BlogCategories { get; set; }
    }
}
