using MvcStock.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcStock.Controllers
{
    public class CustomerController : Controller
    {
        StockDbEntities db = new StockDbEntities();
        // GET: Customer
        public ActionResult Index(string searchValue)
        {
            var values = db.Tbl_Customers.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult NewCustomer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewCustomer(Tbl_Customers p1)
        {
            if (!ModelState.IsValid)
                return View("NewCustomer");
            db.Tbl_Customers.Add(p1);
            db.SaveChanges();
            return View();
        }

        public ActionResult Delete(int ID)
        {
            db.Tbl_Customers.Remove(db.Tbl_Customers.Find(ID));
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetCustomer(int ID)
        {
            return View("GetCustomer", db.Tbl_Customers.Find(ID));
        }

        public ActionResult Update(Tbl_Customers Customer)
        {
            var C = db.Tbl_Customers.Find(Customer.CustomerID);
            C.CustomerName = Customer.CustomerName;
            C.CustomerSurname = Customer.CustomerSurname;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}