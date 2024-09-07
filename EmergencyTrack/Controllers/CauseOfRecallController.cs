using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmergencyTrack.Api.Controllers
{
    public class CauseOfRecallController : Controller
    {
        // GET: CauseOfRecallController
        public ActionResult Index()
        {
            return View();
        }

        // GET: CauseOfRecallController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CauseOfRecallController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CauseOfRecallController/Create
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

        // GET: CauseOfRecallController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CauseOfRecallController/Edit/5
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

        // GET: CauseOfRecallController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CauseOfRecallController/Delete/5
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
