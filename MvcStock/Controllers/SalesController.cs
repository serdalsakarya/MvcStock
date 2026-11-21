using MvcStock.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcStock.Controllers
{
    public class SalesController : Controller
    {
        StockDbEntities db = new StockDbEntities();
        // GET: Sales
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult NewSale()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewSale(Tbl_Sales Sales)
        {
            db.Tbl_Sales.Add(Sales);
            db.SaveChanges();
            return View("Index");
        }
    }
}