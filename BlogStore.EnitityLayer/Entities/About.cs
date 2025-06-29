using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogStore.EnitityLayer.Entities
{
    public class About
    {
        public int AboutId { get; set; }
        public string MainTitle { get; set; }
        public ICollection<AboutSection> Sections { get; set; }
    
    }
}
