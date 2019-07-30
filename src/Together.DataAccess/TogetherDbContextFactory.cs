using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Together.DataAccess
{
    public class TogetherDbContextFactory : IDbContextFactory<TogetherDbContext>
    {
        public TogetherDbContext Create()
        {
            return new TogetherDbContext();
        }
    }
}
