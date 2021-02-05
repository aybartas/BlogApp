using BlogApp.Business.Interfaces;
using BlogApp.DataAccess.Interfaces;
using BlogApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.Business.Concrete
{
    public class CommentService: GenericService<Comment>, ICommentService
    {
        readonly IGenericDal<Comment> genericDal;

        public CommentService(IGenericDal<Comment> genericDal): base(genericDal)
        {
            this.genericDal = genericDal;
        }
    }
}
