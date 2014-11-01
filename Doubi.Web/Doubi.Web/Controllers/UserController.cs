using Doubi.Core.MyEnum;
using Doubi.Service.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Doubi.Core.Domain;

namespace Doubi.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly UserService _us;

        public UserController()
        {
            _us = new UserService();
        }

        public ActionResult Login()
        {
            if (Session["CurrentUser"] != null)
            {
                Response.Redirect("/");
            }

            string referurl = "";

            if (!string.IsNullOrWhiteSpace(Request.QueryString["referurl"]))
            {
                referurl = Request.QueryString["referurl"];
            }
            else
            {
                if (Request.UrlReferrer != null)
                {
                    referurl = Request.UrlReferrer.ToString();
                }
            }
            TempData["referurl"] = referurl;
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password, string checkbox, string vcode)
        {
            string redirecturl = (string)TempData["referurl"];
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                ViewData["errormsg"] = "用户名或密码不能为空！";
                return View();
            }

            if (Session["Vcode"] == null)
            {
                ViewData["errormsg"] = "验证码错误！";
                return View();
            }
            string code = (string)Session["Vcode"];

            if (string.IsNullOrWhiteSpace(vcode))
            {
                ViewData["errormsg"] = "验证码错误！";
                return View();
            }
            bool v_res = code.Equals(vcode, StringComparison.OrdinalIgnoreCase);
            if (!v_res)
            {
                Session["Vcode"] = null;
                ViewData["errormsg"] = "验证码错误！";
                return View();
            }
            //登录
            var result = _us.ValidatUser(username, password);
            if (result != null)
            {
                var customer = _us.GetUserByName(username, (int)UserStatus.Normal);

                Session["CurrentUser"] = customer;
                if (!string.IsNullOrEmpty(checkbox))
                {
                    HttpCookie cookie = new HttpCookie("CurrentUsername");
                    cookie.Value = username;
                    cookie.Expires = DateTime.Now.AddDays(30);
                    Response.Cookies.Add(cookie);
                }
                //跳转到之前的页面 
                if (!string.IsNullOrWhiteSpace(redirecturl))
                {
                    Session["Vcode"] = null;
                    Response.Redirect(redirecturl);
                }
                else
                {
                    Session["Vcode"] = null;
                    Response.Redirect("/");
                }
                return Content("登录成功");

            }
            else
            {
                //传回错误信息
                ViewData["name"] = username;
                ViewData["errormsg"] = "用户名或密码错误";
            }

            return View();
        }

        public ActionResult Regist()
        {
            if (Session["CurrentUser"] != null)
            {
                Response.Redirect("/");
            }
            return View();
        }

        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="username"></param>
        /// <param name="pwd"></param>
        /// <param name="mobile">手机号</param>
        /// <param name="m_vcode">手机校验码=手机号+校验码</param>
        /// <param name="reco_id">推荐人id</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Regist(string username, string pwd, string mobile, string m_vcode, int? reco_id)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(pwd) || string.IsNullOrWhiteSpace(mobile) || string.IsNullOrWhiteSpace(m_vcode))
            {
                ViewData["errormsg"] = "提交参数有误！";
                return View();
            }
            //校验码判断
            if (Session["verify_code"] == null)
            {
                ViewData["errormsg"] = "手机校验码失效，请重新获取！";
                return View();
            }
            string verify_code = (string)Session["verify_code"];
            if (!verify_code.Equals(mobile + m_vcode))
            {
                ViewData["errormsg"] = "校验码错误，请输入正确的手机验证码！";
                return View();
            }
            User user = _us.Regist(username, pwd, mobile, reco_id);
            if (user != null)
            {
                HttpCookie cookie = new HttpCookie("CurrentUsername");
                cookie.Value = username;
                cookie.Expires = DateTime.Now.AddDays(30);
                Response.Cookies.Add(cookie);

                Session["CurrentUser"] = user;
                Session["verify_code"] = null;
                Response.Redirect("/User/RegistSuccess");
            }
            return View();
        }

        public ActionResult RegistSuccess()
        {
            return View();
        }
    }
}
