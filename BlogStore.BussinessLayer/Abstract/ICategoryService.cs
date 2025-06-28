using BlogStore.DataAccessLayer.Dtos;
using BlogStore.EnitityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogStore.BussinessLayer.Abstract
{
    public interface ICategoryService:IGenericService<Category>
    {
        public List<CategoryWithArticleCount> TGetCategoryWithArticleCount();
    }
}
