using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Together.Domain;

namespace Together.BL.Services.Abstract
{
    public interface IPointService : IBaseService<Point>
    {

        Point Zero();
    }
}
