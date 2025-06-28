﻿using BlogStore.BussinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogStore.WebUI.ViewComponents.ArticleDetailViewComponents
{
    public class _ArticleDetailCategoryListComponentPartial : ViewComponent
    {
        private readonly ICategoryService _categoryService;
        public _ArticleDetailCategoryListComponentPartial(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public IViewComponentResult Invoke()
        {
            var values = _categoryService.TGetCategoryWithArticleCount();

            return View(values);  
        }
    }
}
