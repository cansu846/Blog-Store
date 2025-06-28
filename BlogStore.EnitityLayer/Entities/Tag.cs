using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogStore.EnitityLayer.Entities
{
    //Etiket bulutu oluşturmak için kullanılıyor
    //Aramalrda makaleyi one cıkarmaya yarar.
    //or:kadıkoy konser, kenan dogulu vb.
    public class Tag
    {
        public int TagId { get; set; }
        public string Title { get; set; }
    }
}
