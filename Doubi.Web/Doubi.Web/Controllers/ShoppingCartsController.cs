using Doubi.Service.ShoppingCarts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Doubi.Core.Domain;
using Doubi.Service.Products;

namespace Doubi.Web.Controllers
{
    public class ShoppingCartsController : BaseController
    {
        private readonly ShoppingCartService _cartservice;
        private readonly ProductService _ps;

        public ShoppingCartsController()
        {
            _cartservice = new ShoppingCartService();
            _ps = new ProductService();
        }

        /// <summary>
        /// 添加至购物车
        /// </summary>
        /// <returns></returns>
        public string AddUserCart(int pcid, int quantity)
        {
            if (quantity <= 0)
            {
                return AjaxReturn(-1, "商品数量不正确");
            }
            if (pcid <= 0)
            {
                return AjaxReturn(-1, "该商品不存在或已下架");
            }
            HandleAnonym();
            int userid = GetCurrentCustomerId();
            Product pro = _ps.GetProduct(pcid);
            if (pro == null)
            {
                return AjaxReturn(-1, "该商品不存在");
            }
            if (pro.Inventory < quantity)
            {
                return AjaxReturn(-1, "商品库存不足，仅剩" + pro.Inventory + "件！");
            }

            bool r = _cartservice.AddToShoppingCart(userid, pcid, quantity);
            if (r)
            {
                return AjaxReturn(0, "成功添加至购物车！");
            }
            else
            {
                return AjaxReturn(-1, "网络异常，请稍候再试！");
            }
        }

        /// <summary>
        /// 商品移出购物车
        /// </summary>
        /// <param name="cartitem_id"></param>
        /// <returns></returns>
        public string RemoveFromCart(int cartitem_id)
        {
            if (cartitem_id <= 0)
            {
                return AjaxReturn(-1, "购物车无此商品!");
            }
            HandleAnonym();
            int userid = GetCurrentCustomerId();
            bool r = _cartservice.DeleteFromShoppingCart(userid, cartitem_id);
            if (r)
            {
                return AjaxReturn(0, "商品已移出购物车!");
            }
            else
            {
                return AjaxReturn(-1, "网络异常，请稍候再试!");
            }
        }

        /// <summary>
        /// 购物车结算页
        /// </summary>
        /// <returns></returns>
        public ActionResult Settlement()
        {
            HandleAnonym();
            int userid = GetCurrentCustomerId();
            List<ShoppingCart> shoppings = _cartservice.UserShoppingCarts(userid);
            ViewData["shoppings"] = shoppings;
            return View();
        }
    }
}
