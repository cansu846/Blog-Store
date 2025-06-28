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
    public class TagManager : ITagService
    {
        private readonly ITagDal _tagDal;

        public TagManager(ITagDal tagDal)
        {
            _tagDal = tagDal;
        }

        public void TDelete(int id)
        {
            _tagDal.Delete(id);
        }

        public List<Tag> TGetAll()
        {
            return _tagDal.GetAll();
        }

        public Tag TGetById(int id)
        {
           return _tagDal.GetById(id);
        }

        public void TInsert(Tag entity)
        {
            if(entity.Title.Length>=3 && entity.Title.Length <= 20)
            {
                _tagDal.Insert(entity);
            }
            else
            {
                //hata mesajı
            }
        }

        public void TUpdate(Tag entity)
        {
            if (entity.Title != null) { 
                _tagDal.Update(entity);
            }
            else
            {
                //hata mesajı
            }
        }
    }
}
