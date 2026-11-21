using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcStock.Controllers
{
    public class AboutController : Controller
    {
        // GET: Help
        public ActionResult Index()
        {
            return PartialView();
        }
    }
}