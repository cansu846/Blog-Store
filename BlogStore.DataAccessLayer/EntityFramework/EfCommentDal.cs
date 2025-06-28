using BlogStore.DataAccessLayer.Abstract;
using BlogStore.DataAccessLayer.Concrete;
using BlogStore.DataAccessLayer.Context;
using BlogStore.EnitityLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogStore.DataAccessLayer.EntityFramework
{
    public class EfCommentDal : GenericDal<Comment>, ICommentDal
    {
        private readonly BlogContext _blogContext;
        public EfCommentDal(BlogContext context) : base(context)
        {
            _blogContext = context; 
        }

        public List<Comment> GetCommentsByArticle(int articleId)
        {
            var values = _blogContext.Comments.Include(x=>x.AppUser).Include(x=>x.Article).Where(x=>x.ArticleId==articleId).ToList();
            return values;
        }
    }
}
