using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ParkViewer.Models;
using Repositories;

namespace ParkViewer.Controllers
{
    public class WDWDaysController : Controller
    {
        ParkDBContext dbContext = new ParkDBContext();

        // GET: WDWDays
        public ActionResult Index()
        {
            return View();
        }

        // GET: WDWDays
        public JsonResult GetMonth(string start, string end)
        {
            var result = new JsonResult();

            DateTime startDate = DateTime.Now;
            DateTime endDate = Convert.ToDateTime(end);

            ParkOperatingHoursRepository opHours = new ParkOperatingHoursRepository(dbContext);

            var parkHours = opHours.GetAllParkHours(startDate, endDate);

            var rHours = from h in parkHours
                         select new { id = h.Id, title = h.Park.Name, start = h.NormalOpen.Value.ToString("s"), end = h.NormalClose.Value.ToString("s") };

            var rows = rHours.ToArray();

            return Json(rows, JsonRequestBehavior.AllowGet);
        }

        // GET: WDWDays/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WDWDay wDWDay = null;
            if (wDWDay == null)
            {
                return HttpNotFound();
            }
            return View(wDWDay);
        }

        // GET: WDWDays/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WDWDays/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ParkName,ParkDate,ParkActive,HasExtraHours,ParkClosed,ParkReopen,NormalOpen,NormalClose,EarlyOpen,EarlyClose,LateOpen,LateClose")] WDWDay wDWDay)
        {
            if (ModelState.IsValid)
            {
                //db.WDWDays.Add(wDWDay);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(wDWDay);
        }

        // GET: WDWDays/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WDWDay wDWDay = null;
            if (wDWDay == null)
            {
                return HttpNotFound();
            }
            return View(wDWDay);
        }

        // POST: WDWDays/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ParkName,ParkDate,ParkActive,HasExtraHours,ParkClosed,ParkReopen,NormalOpen,NormalClose,EarlyOpen,EarlyClose,LateOpen,LateClose")] WDWDay wDWDay)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(wDWDay).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(wDWDay);
        }

        // GET: WDWDays/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WDWDay wDWDay = null;
            if (wDWDay == null)
            {
                return HttpNotFound();
            }
            return View(wDWDay);
        }

        // POST: WDWDays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WDWDay wDWDay = null;
            //db.WDWDays.Remove(wDWDay);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
