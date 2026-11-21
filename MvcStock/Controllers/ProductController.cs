using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStock.Models.Entity;

namespace MvcStock.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        StockDbEntities db = new StockDbEntities();
        public ActionResult Index()
        {
            var values = db.Tbl_Products.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult NewProduct()
        {
            ViewBag.val = (from i in db.Tbl_Categories.ToList()
                           select new SelectListItem
                           {
                               Text = i.CategoryName,
                               Value = i.CategoryID.ToString()
                           }).ToList();
            return View();
        }

        [HttpPost]
        public ActionResult NewProduct(Tbl_Products p1)
        {
            p1.Tbl_Categories = db.Tbl_Categories.Where(m => m.CategoryID == p1.Tbl_Categories.CategoryID).FirstOrDefault();
            db.Tbl_Products.Add(p1);
            db.SaveChanges();
            return RedirectToAction("index");
        }
        public ActionResult Delete(int ID)
        {
            db.Tbl_Products.Remove(db.Tbl_Products.Find(ID));
            db.SaveChanges();
            return RedirectToAction("index");
        }

        public ActionResult GetProduct(int ID)
        {
            ViewBag.val = (from i in db.Tbl_Categories.ToList()
                           select new SelectListItem
                           {
                               Text = i.CategoryName,
                               Value = i.CategoryID.ToString()
                           }).ToList();
            return View("GetProduct", db.Tbl_Products.Find(ID));
        }

        public ActionResult Update(Tbl_Products Product)
        {
            var updatedProduct = db.Tbl_Products.Find(Product.ProductID);
            updatedProduct.ProductName = Product.ProductName;
            updatedProduct.BrandName = Product.BrandName;
            updatedProduct.Price = Product.Price;
            updatedProduct.Stock = Product.Stock;
            updatedProduct.Model = Product.Model;
            updatedProduct.ProductCategory = Product.Tbl_Categories.CategoryID;
            db.SaveChanges();
            return RedirectToAction("index");
        }

    }
}