﻿using BlogStore.DataAccessLayer.Abstract;
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
    public class EfArticleDal : GenericDal<Article>, IArticleDal
    {
        private readonly BlogContext _context;
        public EfArticleDal(BlogContext context) : base(context)
        {
            _context = context; 
        }
        public Article GetArticleBySlug(string slug)
        {
           var article = _context.Articles.FirstOrDefault(x => x.Slug == slug);
            return article;
        }
        public AppUser GetAppUserByArticleId(int id)
        {
            var value = _context.Articles.Where(x=>x.ArticleId==id).Include(x=>x.AppUser).Select(x=>x.AppUser).FirstOrDefault();
            return value;
        }

        public List<Article> GetArticlesLast3()
        {
            return _context.Articles.OrderByDescending(x=>x.ArticleId).Take(3).ToList();  
        }

        public List<Article> GetArticlesWithCategories()
        {
            return _context.Articles.Include(x => x.Category).Include(x=>x.AppUser).Include(x => x.Comments).OrderByDescending(x=>x.ArticleId).ToList();
        }
        public List<Article> GetArticlesByAppUser(string id)
        {
            return _context.Articles.Include(x => x.Category).Include(x => x.Comments).Where(x=>x.AppUserId==id).OrderByDescending(x=>x.ArticleId).ToList();
        }

        public Article GetArticleWithAuthor(int id)
        {
            return _context.Articles.Include(x=>x.AppUser).Include(x=>x.Category).Where(x=>x.ArticleId==id).FirstOrDefault();
        }
    }
}
