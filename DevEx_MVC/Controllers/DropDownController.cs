using DevEx_MVC.Models;
using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevEx_MVC.Controllers
{
    public class DropDownController : Controller
    {
       static  NorthwindEntities db = new NorthwindEntities();

        // GET: DropDown
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult ComboBoxPartial()
        {
            var veri = db.Order_Details;
            return PartialView("_ComboBoxPartial",veri.ToList());
        }




        ////büyük databasede where in ile alması için
        public static IQueryable<Order_Details> Emails { get { return db.Order_Details; } }

        public ActionResult ComboBoxPartial2()
        {
            return PartialView("_ComboBoxPartial2");
        }


    }
}