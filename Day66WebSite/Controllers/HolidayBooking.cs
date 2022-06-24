using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Day66WebSite.Controllers
{
    public class HolidayBooking : Controller
    {
        // GET: HolidayBooking
        public ActionResult Index()
        {
            // get flight details from AirIndia
            // get flight details from SpiceJet
            // get flight details from FireAirlines



            return View();
        }

        // GET: HolidayBooking/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HolidayBooking/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HolidayBooking/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HolidayBooking/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HolidayBooking/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HolidayBooking/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HolidayBooking/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
