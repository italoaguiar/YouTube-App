using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTube.DataModel
{
    public class HomeData
    {
        public IList<Video> Popular { get; set; }
        public IList<Video> Sports { get; set; }
        public IList<Video> Music { get; set; }
        public IList<Video> Games { get; set; }
        public IList<Video> Movies { get; set; }

    }
}
