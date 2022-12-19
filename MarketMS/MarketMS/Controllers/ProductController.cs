using MarketMS.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MarketMS.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult CreateProduct()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateProduct(Product product)
        {
            var dataBase = new C7MMSEntities();
            dataBase.Products.Add(product);
            dataBase.SaveChanges();
            TempData["message"] = "Successfully Created a product.";
            return RedirectToAction("ShowProduct");
        }
        public ActionResult ShowProduct()
        {
            var dataBase = new C7MMSEntities();
            var product = dataBase.Products.ToList();
            return View(product);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var dataBase = new C7MMSEntities();
            var editProduct = (from st in dataBase.Products
                             where st.Id == id
                             select st).SingleOrDefault();
            return View(editProduct);
        }
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            var dataBase = new C7MMSEntities();
            //
            //db.Books.Find(book.Id);
            var EditProduct = (from st in dataBase.Products
                             where st.Id == product.Id
                             select st).SingleOrDefault();
            EditProduct.Name = product.Name;
            EditProduct.Price = product.Price;
            EditProduct.Qty = product.Qty;

            //db.Entry(ext).CurrentValues.SetValues(book);

            dataBase.SaveChanges();
            TempData["message"] = "Successfully Edited.";

            return RedirectToAction("ShowProduct");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var dataBase = new C7MMSEntities();
            var DelProduct = (from st in dataBase.Products
                             where st.Id == id
                             select st).SingleOrDefault();
            return View(DelProduct);
        }
        [HttpPost]
        public ActionResult Delete(Product product)
        {
            var dataBase = new C7MMSEntities();
            //
            //db.Books.Find(book.Id);
            var remove = (from st in dataBase.Products
                          where st.Id == product.Id
                          select st).FirstOrDefault();
            //db.Entry(ext).CurrentValues.SetValues(book);
            if (remove != null)
            {
                dataBase.Products.Remove(remove);
            }

            dataBase.SaveChanges();
            TempData["message"] = "Successfully deleted a product.";

            return RedirectToAction("ShowProduct");
        }
        public ActionResult Cart(int id)
        {
            var dataBase = new C7MMSEntities();
            var cart = (from st in dataBase.Products
                              where st.Id == id
                              select st).SingleOrDefault();
            Session["Cart"] = cart;

            return View();
        }
    }
}