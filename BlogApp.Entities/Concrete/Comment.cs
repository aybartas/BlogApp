using BlogApp.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.Entities.Concrete
{
   public class Comment : ITable
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string AuthorName { get; set; }
        public string AuthorSurname { get; set; }
        public string AuthorEmail { get; set; }
        public DateTime PublishedTime { get; set; } = DateTime.Now;
        public bool ApprovalStatus { get; set; }

        public int? ParentCommentId { get; set; }
        public Comment ParentComment { get; set; }

        public List<Comment> Replies { get; set; }

        public int RelatedBlogId { get; set; }
        public Blog RelatedBlog { get; set; }


    }
}
