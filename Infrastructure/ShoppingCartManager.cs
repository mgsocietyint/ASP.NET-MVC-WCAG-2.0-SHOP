using Disabled.DAL;
using Disabled.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;

namespace Disabled.Infrastructure
{
    public class ShoppingCartManager
    {
        private ShopContext db;

        private ISessionManager session;

        public const string CartSessionKey = "CartData";

        public ShoppingCartManager(ISessionManager session, ShopContext db)
        {
            this.session = session;
            this.db = db;
        }

        public void AddToCart(int productid)
        {
            var cart = this.GetCart();

            var cartItem = cart.Find(c => c.Product.ProductId == productid);

            if (cartItem != null)
            {
                cartItem.Quantity++;
            }
            else
            {
                var productToAdd = db.Products.Where(p => p.ProductId == productid).SingleOrDefault();
                if (productToAdd != null)
                {
                    var newCartItem = new CartItem()
                    {
                        Product = productToAdd,
                        Quantity = 1,
                        TotalPrice = productToAdd.Price
                    };
                    cart.Add(newCartItem);
                }
            }
            session.Set(CartSessionKey, cart);
        }

        public List<CartItem> GetCart()
        {
            List<CartItem> cart;

            if (session.Get<List<CartItem>>(CartSessionKey) == null)
            {
                cart = new List<CartItem>();
            }
            else
            {
                cart = session.Get<List<CartItem>>(CartSessionKey) as List<CartItem>;
            }
            return cart;
        }

        public int RemoveFromCart(int productid)
        {
            var cart = this.GetCart();

            var cartItem = cart.Find(c => c.Product.ProductId == productid);

            if (cartItem != null)
            {
                if (cartItem.Quantity > 1)
                {
                    cartItem.Quantity--;
                    return cartItem.Quantity;
                }
                else
                {
                    cart.Remove(cartItem);
                }
            }
            return 0;
        }

        public decimal GetCartTotalPrice()
        {
            var cart = this.GetCart();
            return cart.Sum(c => (c.Quantity * c.Product.Price));
        }

        public int GetCartItemsCount()
        {
            var cart = this.GetCart();
            int count = cart.Sum(c => c.Quantity);

            return count;
        }

        public Order CreateOrder(Order newOrder, string userId)
        {
            var cart = this.GetCart();

            newOrder.DateCreated = DateTime.Now;
            newOrder.UserId = userId;

            this.db.Orders.Add(newOrder);

            if (newOrder.OrderItems == null)
            {
                newOrder.OrderItems = new List<OrderItem>();
            }

            decimal cartTotal = 0;

            foreach (var cartItem in cart)
            {
                var newOrderItem = new OrderItem()
                {
                    ProductId = cartItem.Product.ProductId,
                    Quantity = cartItem.Quantity,
                    UnitPrice = cartItem.Product.Price
                };

                cartTotal += (cartItem.Quantity * cartItem.Product.Price);

                newOrder.OrderItems.Add(newOrderItem);
            }

            newOrder.TotalPrice = cartTotal;

            this.db.SaveChanges();

            return newOrder;
        }
        public void EmptyCart()
        {
            session.Set<List<CartItem>>(CartSessionKey, null);
        }
    }
}