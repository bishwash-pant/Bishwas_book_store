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
    public class userController : Controller
    {
        private bishwash_tableEntities1 db = new bishwash_tableEntities1();

        // GET: user
        public ActionResult Index()
        {
            return View(db.user_tables.ToList());
        }

        // GET: user/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user_table user_table = db.user_tables.Find(id);
            if (user_table == null)
            {
                return HttpNotFound();
            }
            return View(user_table);
        }

        // GET: user/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: user/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "user_id,user_name,user_password,user_type")] user_table user_table)
        {
            if (ModelState.IsValid)
            {
                user_table.user_password = this.Hash(user_table.user_password);
                db.user_tables.Add(user_table);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user_table);
        }

        // GET: user/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user_table user_table = db.user_tables.Find(id);
            if (user_table == null)
            {
                return HttpNotFound();
            }
            return View(user_table);
        }

        // POST: user/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "user_id,user_name,user_password,user_type")] user_table user_table)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user_table).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user_table);
        }

        // GET: user/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user_table user_table = db.user_tables.Find(id);
            if (user_table == null)
            {
                return HttpNotFound();
            }
            return View(user_table);
        }

        // POST: user/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            user_table user_table = db.user_tables.Find(id);
            db.user_tables.Remove(user_table);
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
        public string Hash(string password)
        {
            var bytes = new System.Text.UTF8Encoding().GetBytes(password);
           byte[] hashbytes;
            using (var algorithm=new System.Security.Cryptography.SHA512Managed())
            {
                hashbytes = algorithm.ComputeHash(bytes);
            }
            return Convert.ToBase64String(hashbytes);


        }

    }
}
