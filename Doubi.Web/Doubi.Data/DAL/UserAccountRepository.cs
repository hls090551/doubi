using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentData;

namespace Doubi.Data.DAL
{
    public partial class UserAccountRepository<T> 
    {
        public T GetByUserid(int userid)
        {
            using (var context = Context())
            {
                T entity = context.Sql(@"select * from user_account where userid=@userid").Parameter("userid", userid).QuerySingle<T>();
                return entity;
            }
        }
    }
}




