using Doubi.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Doubi.Data.DAL;
using Doubi.Core.MyEnum;
using Doubi.Service.Security;
using Doubi.Data;
using FluentData;

namespace Doubi.Service.Users
{
    public class UserService
    {
        private readonly UserRepository<User> _userRepository;
        private readonly UserAccountRepository<UserAccount> _useraccountRep;
        private readonly UserRecommandRepository<UserRecommand> _recoRepository;
        private readonly EncryptionService _e;

        public UserService()
        {
            _userRepository = new UserRepository<User>();
            _recoRepository = new UserRecommandRepository<UserRecommand>();
            _useraccountRep = new UserAccountRepository<UserAccount>();
            _e = new EncryptionService(new SecuritySettings());
        }

        public User GetUserByName(string username, int status)
        {
            if (status <= 0 || string.IsNullOrWhiteSpace(username))
            {
                return null;
            }
            return _userRepository.GetByUsername(username, status);
        }

        public User GetUserByName(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                return null;
            }
            return _userRepository.GetByUsername(username);
        }

        public User GetUserid(int userid)
        {
            if (userid <= 0)
            {
                return null;
            }
            return _userRepository.GetById(userid);
        }

        public User ValidatUser(string username, string pwd)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(pwd))
            {
                return null;
            }
            User user = _userRepository.GetByUsername(username, (int)UserStatus.Normal);
            if (user == null)
            {
                user = _userRepository.GetByMobile(username, (int)UserStatus.Normal);
            }
            if (user != null)
            {
                pwd = _e.CreatePasswordHash(pwd, user.Salt);
                if (pwd == user.Password)
                {
                    //更新登录时间
                    user.Lastlogintime = DateTime.Now;
                    _userRepository.Update(user);
                    return user;
                }
            }
            return null;
        }

        public User Regist(string username, string pwd, string mobile, int? reco_id)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(pwd) || string.IsNullOrWhiteSpace(mobile))
            {
                return null;
            }
            //校验用户名和手机
            var names = _userRepository.SelectByField("username", username);
            var mobiles = _userRepository.SelectByField("mobile", mobile);
            if (names.Count == 0 && mobiles.Count == 0)
            {
                //1.add user_user
                User user = new User();
                user.Username = username;
                string salt = _e.CreateSaltKey(16);
                string u_pwd = _e.CreatePasswordHash(pwd, salt);
                user.Password = u_pwd;
                user.Salt = salt;
                user.Mobile = mobile;
                user.Viplevel = 1;
                user.Status = (int)UserStatus.Normal;
                user.Createtime = DateTime.Now;
                user.Lastlogintime = DateTime.Now;

                //2.user_account
                UserAccount account = new UserAccount();
                account.Balance = 0;
                account.Paypassword = string.Empty;
                account.Salt = string.Empty;

                using (var context = DBSettings.TransactionContext())
                {
                    _userRepository.InsertWithTransaction(user, context);
                    account.Userid = user.Id;
                    _useraccountRep.InsertWithTransaction(account, context);

                    if (reco_id != null && reco_id > 0)
                    {
                        user.Recommanderid = (int)reco_id;
                        //2.add user_recommand
                        UserRecommand user_reco = new UserRecommand();
                        user_reco.Userid = (int)reco_id;
                        user_reco.Reco_userid = user.Id;
                        user_reco.Totalcontribute = 0;
                        user_reco.Createtime = DateTime.Now;

                        _recoRepository.InsertWithTransaction(user_reco, context);
                    }
                    context.Commit();
                    return user;
                }
            }
            return null;
        }

        public UserAccount GetUserAccount(int userid)
        {
            if (userid <= 0)
            {
                throw new ArgumentException("GetUserAccount args error");
            }
            return _useraccountRep.GetByUserid(userid);
        }
    }
}
