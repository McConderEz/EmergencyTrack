using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmergencyTrack.Api.Controllers
{
    public class SickPersonController : Controller
    {
        // GET: SickPersonController
        public ActionResult Index()
        {
            return View();
        }

        // GET: SickPersonController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SickPersonController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SickPersonController/Create
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

        // GET: SickPersonController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SickPersonController/Edit/5
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

        // GET: SickPersonController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SickPersonController/Delete/5
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
