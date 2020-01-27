using SecurityLab1_Starter.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SecurityLab1_Starter.Controllers
{
    
    public class InventoryController : Controller
    {
        // GET: Inventory
        [Authorize (Users = "testuser2")]
        public ActionResult Index()
        {
            //throw new Exception();
            return View();
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
            filterContext.ExceptionHandled = true;
            //Log the error!!
            Logger.Log(filterContext.Exception.Message,"log.txt");
            Logger.EventLog(filterContext.Exception.Message);
            filterContext.Result = RedirectToAction("Index", "Error");
        }
    }
}