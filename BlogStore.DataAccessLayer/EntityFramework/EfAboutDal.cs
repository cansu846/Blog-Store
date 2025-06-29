using BlogStore.DataAccessLayer.Abstract;
using BlogStore.DataAccessLayer.Concrete;
using BlogStore.DataAccessLayer.Context;
using BlogStore.EnitityLayer.Entities;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogStore.DataAccessLayer.EntityFramework
{
    public class EfAboutDal : GenericDal<About>, IAboutDal
    {
        private readonly BlogContext _blogContext;
        public EfAboutDal(BlogContext context) : base(context)
        {
            _blogContext = context;
        }

        public List<AboutSection> GetAboutSection()
        {
           return _blogContext.AboutSections.ToList();  
        }
    }
}
