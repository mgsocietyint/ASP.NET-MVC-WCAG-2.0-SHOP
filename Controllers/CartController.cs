using Disabled.App_Start;
using Disabled.DAL;
using Disabled.Infrastructure;
using Disabled.Models;
using Disabled.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Disabled.Controllers
{
    public class CartController : Controller
    {
        private ISessionManager sessionManager { get; set; }
        private ShopContext db = new ShopContext();

        public CartController()
        {
            this.sessionManager = new SessionManager();
        }
        public ActionResult Index()
        {
            ShoppingCartManager shoppingCartManager = new ShoppingCartManager(this.sessionManager, this.db);

            var cartItems = shoppingCartManager.GetCart();
            var cartTotalPrice = shoppingCartManager.GetCartTotalPrice();

            CartViewModel cartVM = new CartViewModel() { CartItems = cartItems, TotalPrice = cartTotalPrice };

            return View(cartVM);
        }

        public ActionResult AddToCart(int id)
        {
            ShoppingCartManager shoppingCart = new ShoppingCartManager(this.sessionManager, this.db);
            shoppingCart.AddToCart(id);

            return RedirectToAction("Index", "Cart");
        }

        public ActionResult RemoveFromCart(int productID)
        {
            ShoppingCartManager shoppingCartManager = new ShoppingCartManager(this.sessionManager, this.db);

            int itemCount = shoppingCartManager.RemoveFromCart(productID);
            int cartItemsCount = shoppingCartManager.GetCartItemsCount();
            decimal cartTotal = shoppingCartManager.GetCartTotalPrice();

            var result = new CartRemoveViewModel
            {
                RemoveItemId = productID,
                RemovedItemCount = itemCount,
                CartTotal = cartTotal,
                CartItemsCount = cartItemsCount
            };

            return Json(result);
        }

        public int GetCartItemsCount()
        {
            ShoppingCartManager shoppingCartManager = new ShoppingCartManager(this.sessionManager, this.db);
            return shoppingCartManager.GetCartItemsCount();
        }

        public ApplicationUserManager _userManager;

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public async Task<ActionResult> Checkout()
        {
            if (Request.IsAuthenticated)
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());

                var order = new Order
                {
                    FirstName = user.UserData.FirstName,
                    LastName = user.UserData.LastName,
                    Address = user.UserData.Address,
                    ZipCode = user.UserData.ZipCode,
                    City = user.UserData.City,
                    Email = user.UserData.Email,
                    PhoneNumber = user.UserData.PhoneNumber
                };

                return View(order);
            }
            else
            {
                return RedirectToAction("Login", "Account", new { returnUrl = Url.Action("Checkout", "Cart") });
            }
        }
        [HttpPost]
        public async Task<ActionResult> Checkout(Order orderdetails)
        {
            if (ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId();

                ShoppingCartManager shoppingCartManager = new ShoppingCartManager(this.sessionManager, this.db);
                var newOrder = shoppingCartManager.CreateOrder(orderdetails, userId);

                var user = await UserManager.FindByIdAsync(userId);
                TryUpdateModel(user.UserData);
                await UserManager.UpdateAsync(user);

                shoppingCartManager.EmptyCart();

                //var order = db.Orders.Include("OrderItems").Include("OrderItems.Product").SingleOrDefault(o => o.OrderId == newOrder.OrderId);

                //OrderConfirmationEmail email = new OrderConfirmationEmail();
                //email.To = order.Email;
                //email.Cost = order.TotalPrice;
                //email.OrderNumber = order.OrderId;
                //email.FullAddress = string.Format("{0} {1}, {2}, {3}, {4}", order.FirstName, order.LastName, order.Address, order.ZipCode, order.City);
                //email.OrderItems = order.OrderItems;
                //email.Send();

                return RedirectToAction("OrderConfirmation"); 
            }
            else
            {
                return View(orderdetails);
            }
        }

        public ActionResult OrderConfirmation()
        {
            return View();
        }
    }
}