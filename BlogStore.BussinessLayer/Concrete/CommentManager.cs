using BlogStore.BussinessLayer.Abstract;
using BlogStore.DataAccessLayer.Abstract;
using BlogStore.EnitityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogStore.BussinessLayer.Concrete
{
    public class CommentManager : ICommentService
    {
        private readonly ICommentDal _commentDal;

        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public void TDelete(int id)
        {
            _commentDal.Delete(id);
        }

        public List<Comment> TGetAll()
        {
           return _commentDal.GetAll();
        }

        public Comment TGetById(int id)
        {
            return _commentDal.GetById(id);
        }

        public List<Comment> TGetCommentsByArticle(int id)
        {
            return _commentDal.GetCommentsByArticle(id);
        }

        public void TInsert(Comment entity)
        {
            entity.CommentDate = DateTime.Now;  
            entity.IsValid = false;  
            _commentDal.Insert(entity);
        }

        public void TUpdate(Comment entity)
        {
            entity.CommentDate = DateTime.Now;
            entity.IsValid = false;
            _commentDal.Update(entity);
        }
    }
}
