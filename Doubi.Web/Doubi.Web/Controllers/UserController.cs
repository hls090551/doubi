using Doubi.Core.MyEnum;
using Doubi.Service.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Doubi.Core.Domain;
using Doubi.Service.ShoppingCarts;
using Doubi.Service.Products;

namespace Doubi.Web.Controllers
{
    public class UserController : BaseController
    {
        private readonly UserService _us;
        private readonly ShoppingCartService _cartservice;
        private readonly ProductService _proservice;

        public UserController()
        {
            _us = new UserService();
            _cartservice = new ShoppingCartService();
            _proservice = new ProductService();
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
        public ActionResult Login(string username, string password, string checkbox)
        {
            string redirecturl = (string)TempData["referurl"];
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                ViewData["errormsg"] = "用户名或密码不能为空！";
                return View();
            }

            //if (Session["Vcode"] == null)
            //{
            //    ViewData["errormsg"] = "验证码错误！";
            //    return View();
            //}
            //string code = (string)Session["Vcode"];

            //if (string.IsNullOrWhiteSpace(vcode))
            //{
            //    ViewData["errormsg"] = "验证码错误！";
            //    return View();
            //}
            //bool v_res = code.Equals(vcode, StringComparison.OrdinalIgnoreCase);
            //if (!v_res)
            //{
            //    Session["Vcode"] = null;
            //    ViewData["errormsg"] = "验证码错误！";
            //    return View();
            //}
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
                    cookie.Expires = DateTime.Now.AddDays(7);
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

        public string Checkusername(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                return AjaxReturn(-1, "用户名不能为空");
            }
            var user = _us.GetUserByName(username);
            if (user == null)
            {
                return AjaxReturn(0, "用户名尚未被使用");
            }
            return AjaxReturn(-1, "用户名已经被使用");
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
        public ActionResult Regist(string username, string pwd, string mobile, string m_vcode)
        {
            string recoId = Request.QueryString["recoId"];
            int reco_id = 0;
            if (!string.IsNullOrWhiteSpace(recoId))
            {
                reco_id = Convert.ToInt32(recoId);
            }
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(pwd) || string.IsNullOrWhiteSpace(mobile) || string.IsNullOrWhiteSpace(m_vcode))
            {
                ViewData["errormsg"] = "提交参数有误！";
                return View();
            }
            //校验码判断
            //if (Session["verify_code"] == null)
            //{
            //    ViewData["errormsg"] = "手机校验码失效，请重新获取！";
            //    return View();
            //}
            //string verify_code = (string)Session["verify_code"];
            //if (!verify_code.Equals(mobile + m_vcode))
            //{
            //    ViewData["errormsg"] = "校验码错误，请输入正确的手机验证码！";
            //    return View();
            //}
            User user = _us.Regist(username, pwd, mobile, reco_id);
            if (user != null)
            {
                HttpCookie cookie = new HttpCookie("CurrentUsername");
                cookie.Value = HttpUtility.UrlEncode(username);
                cookie.Expires = DateTime.Now.AddDays(7);
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

        /// <summary>
        /// 用户购物车
        /// </summary>
        /// <returns></returns>
        public string ShoppingCart()
        {
            if (Session["CurrentUser"] == null)
            {
                return "";
            }
            User customer = GetCurrentCustomer();
            var cartitems = _cartservice.UserShoppingCarts(customer.Id);
            string jss = Serializer(cartitems);
            return jss;
        }

        /// <summary>
        /// 添加用户购物车
        /// </summary>
        /// <param name="proid"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public string Addcart(int proid, int quantity)
        {
            HandleAnonym();
            int userid = GetCurrentCustomerId();
            if (proid <= 0 || quantity <= 0)
            {
                return "";
            }
            Product product = _proservice.GetProduct(proid);
            if (product == null || product.Isonsale == false)
            {
                return AjaxReturn(-1, "商品已经下架");
            }
            if (product.Inventory < quantity)
            {
                return AjaxReturn(-1, "库存数量不足");
            }
            bool res = _cartservice.AddToShoppingCart(userid, proid, quantity);
            if (res)
            {
                return AjaxReturn(0, "添加商品成功");
            }
            return AjaxReturn(-1, "系统异常，请稍候再试");
        }

        /// <summary>
        /// 删除购物车数据
        /// </summary>
        /// <param name="cartid"></param>
        /// <returns></returns>
        public string Outcart(int cartid)
        {
            HandleAnonym();
            int userid = GetCurrentCustomerId();
            if (cartid <= 0)
            {
                return AjaxReturn(-1, "商品已删除");
            }
            bool res = _cartservice.DeleteFromShoppingCart(userid, cartid);
            if (res)
            {
                return AjaxReturn(0, "商品已从购物车删除");
            }
            else
            {
                return AjaxReturn(-1, "系统异常，请稍候再试");
            }
        }

    }
}
