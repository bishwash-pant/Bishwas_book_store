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
    public class productController : Controller
    {
        private bishwash_tableEntities1 db = new bishwash_tableEntities1();

        // GET: product
        public ActionResult Index()
        {
            var product_tables = db.product_tables.Include(p => p.category_table);
            return View(product_tables.ToList());
        }

        // GET: product/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            product_table product_table = db.product_tables.Find(id);
            if (product_table == null)
            {
                return HttpNotFound();
            }
            return View(product_table);
        }

        // GET: product/Create
        public ActionResult Create()
        {
            ViewBag.cat_id = new SelectList(db.category_tables, "cat_id", "cat_name");
            return View();
        }

        // POST: product/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "product_id,product_name,product_price,product_quantity,product_details,cat_id")] product_table product_table)
        {
            if (ModelState.IsValid)
            {
                db.product_tables.Add(product_table);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cat_id = new SelectList(db.category_tables, "cat_id", "cat_name", product_table.cat_id);
            return View(product_table);
        }

        // GET: product/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            product_table product_table = db.product_tables.Find(id);
            if (product_table == null)
            {
                return HttpNotFound();
            }
            ViewBag.cat_id = new SelectList(db.category_tables, "cat_id", "cat_name", product_table.cat_id);
            return View(product_table);
        }

        // POST: product/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "product_id,product_name,product_price,product_quantity,product_details,cat_id")] product_table product_table)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product_table).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cat_id = new SelectList(db.category_tables, "cat_id", "cat_name", product_table.cat_id);
            return View(product_table);
        }

        // GET: product/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            product_table product_table = db.product_tables.Find(id);
            if (product_table == null)
            {
                return HttpNotFound();
            }
            return View(product_table);
        }

        // POST: product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            product_table product_table = db.product_tables.Find(id);
            db.product_tables.Remove(product_table);
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
