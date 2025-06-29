using BlogStore.EnitityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogStore.DataAccessLayer.Abstract
{
    public interface IAboutDal:IGenericDal<About>
    {
        List<AboutSection> GetAboutSection();
    }
}
