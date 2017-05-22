using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Together.DAL.Utils;

namespace Together.BL.Utils
{
    public class Filter
    {
        public string OrderBy { get; set; }
        public OrderDir OrderDir { get; set; }

        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
