using BlogStore.DataAccessLayer.Abstract;
using BlogStore.DataAccessLayer.Concrete;
using BlogStore.DataAccessLayer.Context;
using BlogStore.EnitityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogStore.DataAccessLayer.EntityFramework
{
    public class EfTagDal : GenericDal<Tag>, ITagDal
    {
        public EfTagDal(BlogContext context) : base(context)
        {
        }
    }
}
