using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Together.DAL.Utils
{
    public enum OrderDir
    {
        Asc = 0,
        Desc = 1
    }

    public class Filter
    {
        public string OrderBy { get; set; }
        public OrderDir OrderDir { get; set; }

        public int Page { get; set; }
        public int PageSize { get; set; }

    }
}
