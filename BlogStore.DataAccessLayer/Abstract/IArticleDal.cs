using BlogStore.EnitityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogStore.DataAccessLayer.Abstract
{
    public interface IArticleDal:IGenericDal<Article>
    {
        List<Article> GetArticlesWithCategories();
        List<Article> GetArticlesLast3();
        AppUser GetAppUserByArticleId(int id);
        List<Article> GetArticlesByAppUser(string id);
        Article GetArticleWithAuthor(int id);
        Article GetArticleBySlug(string slug);
    }
}
