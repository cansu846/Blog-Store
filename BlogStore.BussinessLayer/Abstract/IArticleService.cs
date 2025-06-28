using BlogStore.EnitityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogStore.BussinessLayer.Abstract
{
    public interface IArticleService:IGenericService<Article>
    {
        public List<Article> TGetArticlesWithCategories();
        public List<Article> TGetArticlesLast3();
        public AppUser TGetAppUserByArticleId(int id);
        List<Article> TGetArticlesByAppUser(string id);
    }
}
