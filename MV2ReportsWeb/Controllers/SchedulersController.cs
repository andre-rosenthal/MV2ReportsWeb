using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using MV2ReportsWeb.MeisterCalls.Schedule;
using SDK = MeisterCore;
using System.Web;
using System.Web.Mvc;
using MV2ReportsWeb.Models;
using System.Text;
using System.Security.Claims;
using MV2ReportsWeb.Utils;

namespace MV2ReportsWeb.Controllers
{
    public class SchedulersController : Controller
    {
        private MV2ReportsWebContext db = new MV2ReportsWebContext();

        // GET: Schedulers
        [HttpGet]
        public ActionResult Index()
        {
            List<Request> req = new List<Request>();
            SDK.Resource<Request, Response> resource = new SDK.Resource<Request, Response>(new Uri("Http://mv2gtw0001:8000"));
            string psw = "DemoUser.";
            resource.Authenticate("DEMOUSER", Encoding.ASCII.GetBytes(psw));
            List<Response> res = new List<Response>();
            Request request = new Request();
            request.Userid = "DEMOUSER";
            req.Add(request);
            try
            {
                res = resource.Execute("Meister.SDK.Reports.Agenda", req);
            }
            catch (SDK.MeisterException ex)
            {
            }
            if (ModelState.IsValid)
            {               
                db.Schedulers.RemoveRange(db.Schedulers);
                foreach (var v in res)
                    foreach (var v1 in v.Agenda)
                    {
                        var s = db.Schedulers.Create();
                        s.UserName = request.Userid;
                        s.TimeSlot = v1.TimeSlot;
                        s.NickName = v1.Nickname;
                        Guid guid = Guid.Empty;
                        if (Guid.TryParse(v1.Pky, out guid))
                        {
                            s.UUID = guid.ToString();
                            s.UUID = s.UUID.Substring(s.UUID.LastIndexOf("-") + 1);
                        }
                        s.ScheduleType = Enum.GetName(typeof(ScheduleTypes), Utils.Utils.GetSchedule(v1.Type));
                        s.WeekDay = Enum.GetName(typeof(Weekdays), Utils.Utils.GetWeekdays(v1.DayOfWeek));
                        db.Schedulers.Add(s);
                    }
                db.SaveChanges();
                IEnumerable<Scheduler> list = from s in db.Schedulers where s.UserName == request.Userid select s;
                return View(list);
            }
            return View(db.Schedulers.FirstOrDefault());
        }

        // GET: MyReports
        [HttpPost]
        public ActionResult Index(MyReports reports)
        {
            return View(db.MyReports.ToList());
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
        public ActionResult Create([Bind(Include = "ID,ScheduleType,WeekDay,TimeSlot,NickName,UUID")] Scheduler scheduler)
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
        public ActionResult Edit([Bind(Include = "ID,ScheduleType,WeekDay,TimeSlot,NickName,UUID")] Scheduler scheduler)
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
