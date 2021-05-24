using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace DevEx_MVC.Controllers
{
    public class GridView1Controller : Controller
    {
        DevEx_MVC.Models.NorthwindEntities db = new DevEx_MVC.Models.NorthwindEntities();

        // GET: GridView1
        public ActionResult Index()
        {
            return View();
        }


        [ValidateInput(false)]
        public ActionResult GridViewPartial()
        {
            var model = db.Categories.Include(x=>x.Products).ToList();
            ViewBag.products = db.Products.ToList();
            return PartialView("_GridViewPartial", model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] DevEx_MVC.Models.Categories item)
        {
            var model = db.Categories;
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
            ViewBag.products = db.Products.ToList();

            return PartialView("_GridViewPartial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] DevEx_MVC.Models.Categories item)
        {
            ViewBag.products = db.Products.ToList();

            var model = db.Categories;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.CategoryID == item.CategoryID);
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
            return PartialView("_GridViewPartial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialDelete(System.Int32 CategoryID)
        {
            var model = db.Categories;
            if (CategoryID >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.CategoryID == CategoryID);
                    if (item != null)
                        model.Remove(item);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_GridViewPartial", model.ToList());
        }

        protected override void Dispose(bool disposing)
        {
           
            db.Dispose();
        }
    }
}