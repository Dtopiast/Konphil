using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konphil.Core.Models
{
    public class Search
    {
        public int SearchId { get; set; }
        public string Article { get; set; }
        public Market Market { get; set; }
        public ArtciclesOrder Order { get; set; }
        public int Page { get; set; }
    }
}
