using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Bishwas_book_store;

namespace Bishwas_book_store.Controllers
{
    public class categoryController : Controller
    {
        private bishwash_tableEntities1 db = new bishwash_tableEntities1();

        // GET: category
        public ActionResult Index()
        {
            return View(db.category_tables.ToList());
        }

        // GET: category/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            category_table category_table = db.category_tables.Find(id);
            if (category_table == null)
            {
                return HttpNotFound();
            }
            return View(category_table);
        }

        // GET: category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: category/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cat_id,cat_name")] category_table category_table)
        {
            if (ModelState.IsValid)
            {
                db.category_tables.Add(category_table);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(category_table);
        }

        // GET: category/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            category_table category_table = db.category_tables.Find(id);
            if (category_table == null)
            {
                return HttpNotFound();
            }
            return View(category_table);
        }

        // POST: category/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cat_id,cat_name")] category_table category_table)
        {
            if (ModelState.IsValid)
            {
                db.Entry(category_table).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category_table);
        }

        // GET: category/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            category_table category_table = db.category_tables.Find(id);
            if (category_table == null)
            {
                return HttpNotFound();
            }
            return View(category_table);
        }

        // POST: category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            category_table category_table = db.category_tables.Find(id);
            db.category_tables.Remove(category_table);
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
