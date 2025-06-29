using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogStore.EnitityLayer.Entities
{
    public class AboutSection
    {
        public int AboutSectionId { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public int AboutId { get; set; }
        public About About { get; set; }
    }
}
