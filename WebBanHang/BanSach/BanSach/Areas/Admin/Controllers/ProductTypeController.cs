using BanDongHo.Models;
using BanDongHo.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BanDongHo.Areas.Admin.Controllers
{
    /*quản lý loại sách  */
    [Authorize(Roles = "Admin,Employee")]
    public class ProductTypeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/ProductCategory
        public ActionResult Index()
        {
            var items = db.ProductTypes;
            return View(items);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(ProductType model)
        {
            if (ModelState.IsValid)
            {
                model.CreateDate = DateTime.Now;
                model.ModifiedDate = DateTime.Now;
                model.Alias = BanDongHo.Models.Common.Filter.FilterChar(model.Title);
                db.ProductTypes.Add(model);
                db.SaveChanges();
                return RedirectToAction("index");
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            var item = db.ProductTypes.Find(id);
            return View(item);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductType model)
        {
            if (ModelState.IsValid)
            {
                model.ModifiedDate = DateTime.Now;
                model.Alias = BanDongHo.Models.Common.Filter.FilterChar(model.Title);
                db.ProductTypes.Attach(model);
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = db.ProductTypes.Find(id);
            if (item != null)
            {
                db.ProductTypes.Remove(item);
                db.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
    }
}