using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MV2ReportsWeb.Models;
using MV2ReportsWeb.MeisterCalls;
using SDK = MeisterCore;
using System.Text;
using System.Security.Claims;

namespace MV2ReportsWeb.Controllers
{
    public class MyReportsController : Controller
    {
        private MV2ReportsWebContext db = new MV2ReportsWebContext();

        [HttpGet]
        public ActionResult Index()
        {
            List<MyReportsRequest> req = new List<MyReportsRequest>();
            SDK.Resource<MyReportsRequest,MyReportsResult> resource = new SDK.Resource<MyReportsRequest,MyReportsResult>(new Uri("Http://mv2gtw0001:8000"));
            string psw = "DemoUser.";
            resource.Authenticate("DEMOUSER", Encoding.ASCII.GetBytes(psw));
            List<MyReportsResult> res = new List<MyReportsResult>();
            MyReportsRequest request = new MyReportsRequest();
            request.UserId = "DEMOUSER";
            req.Add(request);
            try
            {
                res = resource.Execute("Meister.SDK.Report.Retrieval", req);
            }
            catch (SDK.MeisterException ex)
            {
            }
            if (ModelState.IsValid)
            {
                Claim sessionEmail = ClaimsPrincipal.Current.FindFirst(ClaimTypes.Email);
                string userEmail = sessionEmail.Value;
                db.MyReports.RemoveRange(db.MyReports);
                foreach (var v in res)
                    foreach (var v1 in v.ReportDatum)
                    {
                        var r = db.MyReports.Create();
                        r.Email = userEmail;
                        r.ReportName = v1.Report.Name;
                        Guid guid = Guid.Empty;
                        if (Guid.TryParse(v1.Pky, out guid))
                            r.UUID = guid.ToString();
                        DateTime dt = Utils.Utils.ToDateTime(v1.Date, v1.Time);
                        r.DateTime = dt;
                        r.Status = Enum.GetName(typeof(MyReports.Statuses), r.ToNamedStatus(v1.Status));
                        db.MyReports.Add(r);
                    }
                db.SaveChanges();
                IEnumerable<MyReports> list = from r in db.MyReports where r.Email == userEmail select r;
                return View(list);
            }
            return View(db.MyReports.FirstOrDefault());
        }

        // GET: MyReports
        [HttpPost]
        public ActionResult Index(MyReports reports)
        {
            return View(db.MyReports.ToList());
        }

        [HttpPost]
        // GET: MyReports/Select/5
        public ActionResult Select(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MV2ReportsWeb.Models.MyReports myReports = db.MyReports.Find(id);
            if (myReports == null)
            {
                return HttpNotFound();
            }
            return View(myReports);
        }

        // GET: MyReports/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MyReports/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ReportName,UUID,Status")] MV2ReportsWeb.Models.MyReports myReports)
        {
            if (ModelState.IsValid)
            {
                db.SaveChanges();
                return RedirectToAction("Index","Schedulers");
            }

            return View(myReports);
        }

        // GET: MyReports/Download/5
        public ActionResult Download(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MV2ReportsWeb.Models.MyReports myReports = db.MyReports.Find(id);
            if (myReports == null)
            {
                return HttpNotFound();
            }
            return View(myReports);
        }

        // POST: MyReports/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ReportName,UUID,Status")] MV2ReportsWeb.Models.MyReports myReports)
        {
            if (ModelState.IsValid)
            {
                db.Entry(myReports).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(myReports);
        }

        // GET: MyReports/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MV2ReportsWeb.Models.MyReports myReports = db.MyReports.Find(id);
            if (myReports == null)
            {
                return HttpNotFound();
            }
            return View(myReports);
        }

        // POST: MyReports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MV2ReportsWeb.Models.MyReports myReports = db.MyReports.Find(id);
            db.MyReports.Remove(myReports);
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
