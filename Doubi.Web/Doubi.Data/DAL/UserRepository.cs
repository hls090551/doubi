using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentData;

namespace Doubi.Data.DAL
{
    public partial class UserRepository<T>
    {
        /// <summary>
        /// 根据用户名获取用户
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public T GetByUsername(string username, int status)
        {
            if (string.IsNullOrWhiteSpace(username) || status <= 0)
            {
                throw new ArgumentNullException("UserRepository.GetByUsername args error");
            }

            using (var context = Context())
            {
                return context.Sql(" select * from user_user where status=@status and username=@username")
                                .Parameter("username", username)
                                .Parameter("status", status)
                                .QuerySingle<T>();
            }
        }

        /// <summary>
        /// 根据手机号码获取用户
        /// </summary>
        /// <param name="mobile"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public T GetByMobile(string mobile, int status)
        {
            if (string.IsNullOrWhiteSpace(mobile) || status <= 0)
            {
                throw new ArgumentNullException("UserRepository.GetByMobile args error");
            }
            using (var context = Context())
            {
                return context.Sql(" select * from user_user where mobile=@mobile and status=@status ")
                     .Parameter("mobile", mobile)
                     .Parameter("status", status)
                     .QuerySingle<T>();
            }
        }
    }
}
