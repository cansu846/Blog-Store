using BlogStore.EnitityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogStore.BussinessLayer.Abstract
{
    public interface ICommentService:IGenericService<Comment>
    {
        public List<Comment> TGetCommentsByArticle(int id);
        public List<Comment> TGetCommentByUser(string userId);
    }
}
