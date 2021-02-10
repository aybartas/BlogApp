using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Client.Models
{
    public class BlogListModel
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public string Definition { get; set; }
        public string Description { get; set; }
        public DateTime PublishedTime { get; set; }
        public string BlogImage { get; set; }

    }
}
