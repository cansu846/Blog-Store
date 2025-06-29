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
    public class AboutManager : IAboutService
    {
        private readonly IAboutDal _AboutDal;

        public AboutManager(IAboutDal AboutDal)
        {
            _AboutDal = AboutDal;
        }

        public void TDelete(int id)
        {
            _AboutDal.Delete(id);
        }

        public List<AboutSection> TGetAboutSection()
        {
            return _AboutDal.GetAboutSection(); 
        }

        public List<About> TGetAll()
        {
            return _AboutDal.GetAll();
        }

        public About TGetById(int id)
        {
           return _AboutDal.GetById(id);
        }

        public void TInsert(About entity)
        {
          
        }

        public void TUpdate(About entity)
        {
         
        }
    }
}
