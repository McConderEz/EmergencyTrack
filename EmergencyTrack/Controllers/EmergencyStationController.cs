using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmergencyTrack.Api.Controllers
{
    public class EmergencyStationController : Controller
    {
        // GET: EmergencyStationController
        public ActionResult Index()
        {
            return View();
        }

        // GET: EmergencyStationController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EmergencyStationController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmergencyStationController/Create
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

        // GET: EmergencyStationController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EmergencyStationController/Edit/5
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

        // GET: EmergencyStationController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmergencyStationController/Delete/5
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
