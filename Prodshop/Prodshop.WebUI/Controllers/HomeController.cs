using Prodshop.core.Models;
using Prodshop.core.ViewModels;
using ProdShop.core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prodshop.WebUI.Controllers
{
    public class HomeController : Controller
    {

        IRepository<Product> context;
        IRepository<ProductCategory> productCategories;
        public HomeController(IRepository<Product> productContext, IRepository<ProductCategory> productCategoryContext)
        {
            context = productContext;
            productCategories = productCategoryContext;
        }
        public ActionResult Index(string Category = null)
        {
            List<Product> products;
            List<ProductCategory> categories = productCategories.Collection().ToList();

            if (Category == null)
            {
                products = context.Collection().ToList();
            }
            else
            {
                products = context.Collection().Where(p => p.Category == Category).ToList();
            }
            ProductListViewModel model = new ProductListViewModel();
            model.Products = products;
            model.ProductCategories = categories;

            return View(model);
        }
        public ActionResult Details(string Id)
        {
            Product product = context.Find(Id);
            if (product == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(product);
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        
        public ActionResult RemoveFromCart(String productId)
        {
            List<CartItem> cart = (List<CartItem>)Session["cart"];
            CartItem existingItem = cart.Find(item => item.Product.Id == productId);
            if (existingItem != null)
            {
                if(existingItem.Quantity==1)
                {
                    cart.Remove(existingItem);
                }
                else
                {
                    existingItem.Quantity -= 1; 
                }
                Session["cart"] = cart;
            }
           
            return Redirect("Index");
        }
        public ActionResult AddToCart(String productId)
        {
            // if there is no cart add as a new cart item
            if (Session["cart"] == null)
            {
                List<CartItem> cart = new List<CartItem>();
                Product product = context.Find(productId);
                cart.Add(new CartItem()
                {
                    Product = product,
                    Quantity = 1
                });
                Session["cart"] = cart;
            }
            else
            {
                //check if item already exists in the cart then just increase quantity
                List<CartItem> cart = (List<CartItem>)Session["cart"];
                CartItem existingItem = cart.Find(item => item.Product.Id == productId);
                if(existingItem == null)
                {
                    var product = context.Find(productId);
                    cart.Add(new CartItem()
                    {
                        Product = product,
                        Quantity = 1
                    });
                }
                else
                {
                    existingItem.Quantity += 1;
                }
                
                Session["cart"] = cart;
            }
            return Redirect("Index");
        }
    }
}