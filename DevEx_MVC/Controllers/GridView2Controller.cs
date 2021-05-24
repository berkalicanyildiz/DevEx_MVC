using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevEx_MVC.Controllers
{
    public class GridView2Controller : Controller
    {
        // GET: GridView2
        public ActionResult Index()
        {
            return View();
        }

        DevEx_MVC.Models.NorthwindEntities db = new DevEx_MVC.Models.NorthwindEntities();

        [ValidateInput(false)]
        public ActionResult GridView2Partial()
        {
            //var model = db.Orders.AsQueryable();
            //return PartialView("_GridView2Partial", model.ToList());
            return PartialView("_GridView2Partial");

        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridView2PartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] DevEx_MVC.Models.Order_Details item)
        {
            var model = db.Order_Details;
            if (ModelState.IsValid)
            {
                try
                {
                    model.Add(item);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_GridView2Partial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridView2PartialUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] DevEx_MVC.Models.Order_Details item)
        {
            var model = db.Order_Details;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.OrderID == item.OrderID);
                    if (modelItem != null)
                    {
                        this.UpdateModel(modelItem);
                        db.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_GridView2Partial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridView2PartialDelete(System.Int32 OrderID)
        {
            var model = db.Order_Details;
            if (OrderID >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.OrderID == OrderID);
                    if (item != null)
                        model.Remove(item);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_GridView2Partial", model.ToList());
        }
    }
}