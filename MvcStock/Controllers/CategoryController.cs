using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStock.Models.Entity;

namespace MvcStock.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        StockDbEntities db = new StockDbEntities();
        public ActionResult Index()
        {
            var values = db.Tbl_Categories.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult NewCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewCategory(Tbl_Categories category)
        {
            if (!ModelState.IsValid)
            {
                return View("NewCategory");
            }
            db.Tbl_Categories.Add(category);
            db.SaveChanges();
            return View();
        }

        public ActionResult Delete(int ID)
        {
            db.Tbl_Categories.Remove(db.Tbl_Categories.Find(ID));
            db.SaveChanges();
            return RedirectToAction("index");
        }

        public ActionResult GetCategory(int ID)
        {
            return View("GetCategory", db.Tbl_Categories.Find(ID));
        }

        public ActionResult Update(Tbl_Categories category)
        {
            db.Tbl_Categories.Find(category.CategoryID).CategoryName = category.CategoryName;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}