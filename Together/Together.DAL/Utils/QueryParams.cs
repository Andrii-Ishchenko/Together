using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Together.DAL.Utils
{
    public enum OrderDir
    {
        Asc = 0,
        Desc = 1
    }

    public class QueryParams<TEntity>
        where TEntity : class
    {
        Expression<Func<TEntity, bool>> predicate;

        Expression<Func<TEntity, object>> orderBy;
        OrderDir _orderDirection = OrderDir.Asc;

        string[] includeProperties;

        int _page = 1;
        int _pageSize = 10;

        public OrderDir OrderDirection
        {
            get { return _orderDirection; }
            set { _orderDirection = value; }
        }

        public int Page
        {
            get
            {
                return _page;
            }

            set
            {
                _page = value;
            }
        }

        public int PageSize
        {
            get
            {
                return _pageSize;
            }

            set
            {
                _pageSize = value;
            }
        }

        public string[] IncludeProperties
        {
            get
            {
                return includeProperties;
            }

            set
            {
                includeProperties = value;
            }
        }

        public Expression<Func<TEntity, bool>> Predicate
        {
            get
            {
                return predicate;
            }

            set
            {
                predicate = value;
            }
        }

        public Expression<Func<TEntity, object>> OrderBy
        {
            get
            {
                return orderBy;
            }

            set
            {
                orderBy = value;
            }
        }
    }
}
