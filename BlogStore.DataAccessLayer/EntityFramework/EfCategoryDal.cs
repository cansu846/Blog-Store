using BlogStore.DataAccessLayer.Abstract;
using BlogStore.DataAccessLayer.Concrete;
using BlogStore.DataAccessLayer.Context;
using BlogStore.DataAccessLayer.Dtos;
using BlogStore.EnitityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogStore.DataAccessLayer.EntityFramework
{
    public class EfCategoryDal : GenericDal<Category>, ICategoryDal
    {
        private readonly BlogContext _context;
        public EfCategoryDal(BlogContext context) : base(context)
        {
            _context = context; 
        }

        public List<CategoryWithArticleCount> GetCategoryWithArticleCount()
        {
            var result = _context.Categories.Select(c => new CategoryWithArticleCount
            {
                CategoryName = c.CategoryName,
                ArticleCount = _context.Articles.Count(x=>x.CategoryId==c.CategoryId)
            }).ToList();

            return result;
        }
    }
}
