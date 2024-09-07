using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmergencyTrack.Api.Controllers
{
    public class SocialStatusController : Controller
    {
        // GET: SocialStatusController
        public ActionResult Index()
        {
            return View();
        }

        // GET: SocialStatusController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SocialStatusController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SocialStatusController/Create
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

        // GET: SocialStatusController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SocialStatusController/Edit/5
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

        // GET: SocialStatusController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SocialStatusController/Delete/5
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
