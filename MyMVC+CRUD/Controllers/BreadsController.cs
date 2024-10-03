using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyMVC_CRUD.Models;

namespace MyMVC_CRUD.Controllers
{
    public class BreadsController : Controller
    {
        private BreadEntities db = new BreadEntities();

        // GET: Breads
        public ActionResult Index()
        {
            return View(db.Bread.ToList());
        }

        // GET: Breads/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bread bread = db.Bread.Find(id);
            if (bread == null)
            {
                return HttpNotFound();
            }
            return View(bread);
        }

        // GET: Breads/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Breads/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Price,Inventory,Sales_volume")] Bread bread)
        {
            if (ModelState.IsValid)
            {
                db.Bread.Add(bread);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bread);
        }

        // GET: Breads/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bread bread = db.Bread.Find(id);
            if (bread == null)
            {
                return HttpNotFound();
            }
            return View(bread);
        }

        // POST: Breads/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Price,Inventory,Sales_volume")] Bread bread)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bread).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bread);
        }

        // GET: Breads/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bread bread = db.Bread.Find(id);
            if (bread == null)
            {
                return HttpNotFound();
            }
            return View(bread);
        }

        // POST: Breads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bread bread = db.Bread.Find(id);
            db.Bread.Remove(bread);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
