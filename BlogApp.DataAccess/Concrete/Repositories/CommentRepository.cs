using BlogApp.DataAccess.Interfaces;
using BlogApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.DataAccess.Concrete.Repositories
{
    public class CommentRepository : GenericRepository<Comment>, ICommentDal
    {

    }
}
