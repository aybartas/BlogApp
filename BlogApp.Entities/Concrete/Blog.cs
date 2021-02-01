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
        public int Definition { get; set; }
        public string Description { get; set; }
        public DateTime PublishedTime { get; set; }
        public string BlogImage { get; set; }

        public List<BlogCategory> BlogCategories { get; set; }

    }
}
