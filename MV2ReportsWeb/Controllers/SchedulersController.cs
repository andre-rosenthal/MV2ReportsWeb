using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MV2ReportsWeb.Models;

namespace MV2ReportsWeb.Controllers
{
    public class SchedulersController : Controller
    {
        private MV2ReportsWebContext db = new MV2ReportsWebContext();

        // GET: Schedulers
        [HttpGet]
        public ActionResult Index()
        {
            return View(db.Schedulers.ToList());
        }

        // GET: Schedulers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Scheduler scheduler = db.Schedulers.Find(id);
            if (scheduler == null)
            {
                return HttpNotFound();
            }
            return View(scheduler);
        }

        // GET: Schedulers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Schedulers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Hint,ReportName,ReporDescription")] Scheduler scheduler)
        {
            if (ModelState.IsValid)
            {
                db.Schedulers.Add(scheduler);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(scheduler);
        }

        // GET: Schedulers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Scheduler scheduler = db.Schedulers.Find(id);
            if (scheduler == null)
            {
                return HttpNotFound();
            }
            return View(scheduler);
        }

        // POST: Schedulers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Hint,ReportName,ReporDescription")] Scheduler scheduler)
        {
            if (ModelState.IsValid)
            {
                db.Entry(scheduler).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(scheduler);
        }

        // GET: Schedulers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Scheduler scheduler = db.Schedulers.Find(id);
            if (scheduler == null)
            {
                return HttpNotFound();
            }
            return View(scheduler);
        }

        // POST: Schedulers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Scheduler scheduler = db.Schedulers.Find(id);
            db.Schedulers.Remove(scheduler);
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
