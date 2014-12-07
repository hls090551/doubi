using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentData;
using Doubi.Core.PagedList;

namespace Doubi.Data.DAL
{
    public partial class OrderRepository<T>
    {
        //count
        public int CountByWhere(string where, Dictionary<string, object> paramArr, string sql)
        {
            using (var context = Context())
            {
                var select = context.Sql(sql + where);
                foreach (var key in paramArr.Keys)
                {
                    select.Parameter(key, paramArr[key]);
                }
                return select.QuerySingle<int>();
            }
        }

        //多条件查询
        public List<T> MultiQuery(int page, int size, int? userid, short? type, short? status, decimal? startvalue, decimal? endvalue, DateTime? starttime, DateTime? endtime, string sortExpression)
        {
            List<T> result = null;
            StringBuilder where = new StringBuilder();
            where.Append(" 1 = 1 ");
            ISelectBuilder<T> select = null;
            Dictionary<string, object> sqlparams = new Dictionary<string, object>();

            using (var context = Context())
            {
                select = context.Select<T>(" * ")
                        .From("order_order");

                if (userid != 0)
                {
                    where.Append(" and userid=@userid ");
                    sqlparams.Add("userid", userid);
                }
                if (type != null)
                {
                    where.Append(" and type=@type ");
                    sqlparams.Add("type", type);
                }
                if (status != null)
                {
                    where.Append(" and status=@status ");
                    sqlparams.Add("status", status);
                }

                if (startvalue == null || startvalue == 0)
                {
                    if (endvalue != null)
                    {
                        where.Append(" and goodsvalue >= @goodsvalue ");
                        sqlparams.Add("goodsvalue", startvalue);
                    }
                }
                else
                {
                    if (endvalue == null)
                    {
                        where.Append(" and goodsvalue >= @goodsvalue ");
                        sqlparams.Add("goodsvalue", startvalue);

                    }
                    else
                    {
                        where.Append(" and goodsvalue between @startvalue and @endvalue ");
                        sqlparams.Add("startvalue", startvalue);
                        sqlparams.Add("endvalue", endvalue);
                    }
                }
                if (starttime != null)
                {
                    where.Append(" and createtime>= @starttime ");
                    sqlparams.Add("starttime", starttime);
                }
                if (endtime != null)
                {
                    where.Append(" and createtime<=@endtime ");
                    sqlparams.Add("endtime", endtime);
                }

                select.Where(where.ToString());
                foreach (var key in sqlparams.Keys)
                {
                    select.Parameter(key, sqlparams[key]);
                }

                if (size > 0)
                {
                    if (size <= 0)
                        page = 1;

                    select.Paging(page, size);
                }

                if (!string.IsNullOrEmpty(sortExpression))
                    select.OrderBy(sortExpression);
                else
                    select.OrderBy("Id desc");

                result = select.QueryMany();
            }

            if (size > 0)
            {
                string sql = " select count(*) from order_order where ";
                return new PagedList<T>(result, page, size, CountByWhere(where.ToString(), sqlparams, sql));
            }
            else
            {
                return result;
            }
        }

        public T GetbyOrderno(long orderno)
        {
            if (orderno <= 0)
            {
                throw new ArgumentException("OrderRepository.GetbyOrderno args error!");
            }
            var res = this.SelectByField("orderno", orderno);
            if (res != null && res.Count > 0)
            {
                return res[0];
            }
            return null;
        }
    }
}




