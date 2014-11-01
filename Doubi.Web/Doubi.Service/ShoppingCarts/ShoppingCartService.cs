using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Doubi.Core.Domain;
using Doubi.Data.DAL;
namespace Doubi.Service.ShoppingCarts
{
    public class ShoppingCartService
    {
        private readonly ShoppingCartRepository<ShoppingCart> _cartRepository;
        private readonly ProductRepository<Product> _proRepository;

        public ShoppingCartService()
        {
            _cartRepository = new ShoppingCartRepository<ShoppingCart>();
            _proRepository = new ProductRepository<Product>();

        }

        //展示当前购物车商品信息
        public List<ShoppingCart> UserShoppingCarts(int userid)
        {
            if (userid <= 0)
            {
                return null;
            }
            return _cartRepository.SelectByField("userid", userid);
        }

        //根据cartitem_id查询
        public ShoppingCart GetShoppingItem(int cartitem_id)
        {
            if (cartitem_id <= 0)
            {
                return null;
            }
            var cartitems = _cartRepository.SelectByField("id", cartitem_id);
            if (cartitems == null || cartitems.Count <= 0)
            {
                return null;
            }
            else
            {
                return cartitems[0];
            }
        }

        //加入购物车
        public bool AddToShoppingCart(int userid, int pcid, int quantity)
        {
            if (userid <= 0 || pcid <= 0 || quantity <= 0)
            {
                return false;
            }
            ShoppingCart cart = _cartRepository.GetShoppingCart(userid, pcid);
            if (cart == null)
            {
                Product pro = _proRepository.GetById(pcid);
                if (pro == null)
                {
                    return false;
                }
                cart = new ShoppingCart();
                cart.Userid = userid;
                cart.Pcid = pcid;
                cart.Goodsname = pro.Pname;
                cart.Quantity = quantity;
                cart.Weigth = pro.Weight;
                cart.Price = pro.Price;
                cart.Needshipping = pro.Need_deliver;
                cart.Addtime = DateTime.Now;

                return _cartRepository.Insert(cart);
            }
            else
            {
                cart.Quantity = cart.Quantity + quantity;
                return _cartRepository.Update(cart);
            }
        }

        //从购物车删除
        public bool DeleteFromShoppingCart(int userid, int cartitem_id)
        {
            if (cartitem_id <= 0 || userid <= 0)
            {
                return false;
            }
            bool r = CheckShoppingItem(userid, cartitem_id);
            if (r)
            {
                return _cartRepository.Delete(cartitem_id);
            }
            return false;
        }

        //更新购物车
        public bool UpdateShoppingCarts(int userid, ShoppingCart item)
        {
            if (item == null)
            {
                return false;
            }
            if (userid != item.Userid)
            {
                return false;
            }
            return _cartRepository.Update(item);
        }

        //更新数量
        public bool UpdateQuantity(int userid, int cartitem_id, int quantity)
        {
            if (userid <= 0 || cartitem_id <= 0 || quantity <= 0)
            {
                return false;
            }
            ShoppingCart cartitem = _cartRepository.SelectByField("id", cartitem_id)[0];
            if (cartitem.Userid != userid)
            {
                return false;
            }
            cartitem.Quantity = quantity;
            return _cartRepository.Update(cartitem);
        }

        //批量更新购物车数量
        public bool UpdateShoppingCarts(int userid, List<int> cartitem_ids, List<int> cartitem_quantites)
        {
            int flag = 0;
            if (userid <= 0)
            {
                return false;
            }
            if (cartitem_ids == null || cartitem_quantites == null || cartitem_quantites.Count <= 0 || cartitem_ids.Count <= 0)
            {
                return false;
            }
            if (cartitem_ids.Count != cartitem_quantites.Count)
            {
                return false;
            }
            //循环更新
            for (int i = 0; i < cartitem_ids.Count; i++)
            {
                bool r = UpdateQuantity(userid, cartitem_ids[i], cartitem_quantites[i]);
                if (r)
                {
                    flag++;
                }
            }

            return flag == cartitem_ids.Count;
        }

        //校验购物车是否为该用户的
        public bool CheckShoppingItem(int userid, int cartitem_id)
        {
            if (userid <= 0 || cartitem_id <= 0)
            {
                return false;
            }
            ShoppingCart cartitem = GetShoppingItem(cartitem_id);
            if (cartitem == null)
            {
                return false;
            }
            if (cartitem.Userid == userid)
            {
                return true;
            }
            return false;
        }
    }
}
