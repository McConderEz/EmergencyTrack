using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmergencyTrack.Api.Controllers
{
    public class AmbulanceRequestController : Controller
    {
        // GET: AmbulanceRequestController
        public ActionResult Index()
        {
            return View();
        }

        // GET: AmbulanceRequestController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AmbulanceRequestController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AmbulanceRequestController/Create
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

        // GET: AmbulanceRequestController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AmbulanceRequestController/Edit/5
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

        // GET: AmbulanceRequestController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AmbulanceRequestController/Delete/5
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
