using Doubi.Core.Domain;
using Doubi.Core.MyEnum;
using Doubi.Service.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Doubi.Web.Controllers
{
    public class BaseController : Controller
    {
        public string Serializer(object objects)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            return js.Serialize(objects);
        }

        internal string AjaxReturn(int errorcode, string msg)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            return js.Serialize(new { errorcode = errorcode, msg = msg });
        }

        internal T DeSerializer<T>(string input)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            return js.Deserialize<T>(input);
        }

        public void HandleAnonym()
        {
            if (!this.IsLogin())
            {
                //这里面可以输出一段脚本 弹出一个登录框
                string redirectUrl = "/User/Login";
                Response.Redirect(redirectUrl, true);
            }
        }

        public bool IsLogin()
        {
            if (Session["CurrentUser"] == null)
            {
                return false;
            }
            return true;
        }

        public string GetCurrentUsername()
        {
            if (Session["CurrentUser"] == null)
            {
                return string.Empty;
            }
            var customer = Session["CurrentUser"] as User;
            return customer.Username;
        }

        public int GetCurrentCustomerId()
        {
            if (Session["CurrentUser"] != null)
            {
                return (Session["CurrentUser"] as User).Id;
            }
            return 0;
        }

        public void LogOut()
        {
            if (Request.Cookies["CurrentUsername"] != null)
            {
                HttpCookie cookie = Request.Cookies["CurrentUsername"];
                cookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(cookie);
            }

            Session["CurrentUser"] = null;
            Response.Redirect("/home/index");

        }

        public User GetCurrentCustomer()
        {
            if (Session["CurrentUser"] == null)
            {
                return null;
            }
            return Session["CurrentUser"] as User;
        }


        //在进入页面前操作的方法
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {            
            base.OnActionExecuting(filterContext);
            if (Session["CurrentUser"] == null)
            {
                if (Request.Cookies["CurrentUsername"] != null)
                {                    
                        //根据cookie把用户加入session
                        UserService _us = new UserService();
                        var user = _us.GetUserByName(HttpUtility.UrlDecode(Request.Cookies["CurrentUsername"].Value), (int)UserStatus.Normal);
                        if (user != null)
                        {
                            Session["CurrentUser"] = user;
                            ViewData["Username"] = (Session["CurrentUser"] as User).Username;   
                        }                                                        
                }
                else
                {
                    ViewData["Username"] = "";
                }
            }
            else
            {
                ViewData["Username"] = (Session["CurrentUser"] as User).Username;
            }
        }
    }
}
