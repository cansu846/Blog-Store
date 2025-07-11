﻿using BlogStore.BussinessLayer.Abstract;
using BlogStore.BussinessLayer.Helpers;
using BlogStore.DataAccessLayer.Abstract;
using BlogStore.EnitityLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogStore.BussinessLayer.Concrete
{
    public class ArticleManager : IArticleService
    {
        private readonly IArticleDal _articleDal;

        public ArticleManager(IArticleDal articleDal)
        {
            _articleDal = articleDal;
        }

        public void TDelete(int id)
        {
            _articleDal.Delete(id);
        }

        public List<Article> TGetAll()
        {
            return _articleDal.GetAll();
        }

        public AppUser TGetAppUserByArticleId(int id)
        {
            return _articleDal.GetAppUserByArticleId(id);
        }

        public List<Article> TGetArticlesLast3()
        {
            return _articleDal.GetArticlesLast3();
        }

        public List<Article> TGetArticlesWithCategories()
        {
           return _articleDal.GetArticlesWithCategories();
        }

        public Article TGetById(int id)
        {
            return _articleDal.GetById(id);
        }

        public void TInsert(Article entity)
        {
            entity.Slug = SlugHelper.GenerateSlug(entity.Title);

            if (entity.Title.Length >= 3 && entity.Title.Length <= 100 &&
                entity.Description != "")
                {
                _articleDal.Insert(entity);
            }
            else
            {
                //hata mesajı 
            }
        }
        public void TUpdate(Article entity)
        {
            if(entity.Description!="" && entity.Title != "")
            {
                _articleDal.Update(entity);
            }
            else
            {
                //hata mesajı
            }
        }
        public List<Article> TGetArticlesByAppUser(string id)
        {
            return _articleDal.GetArticlesByAppUser(id);
        }

        public Article TGetArticleWithAuthor(int id)
        {
            return _articleDal.GetArticleWithAuthor(id);
        }

        public Article TGetArticleBySlug(string slug)
        {
            return _articleDal.GetArticleBySlug(slug);
        }
    }
}
