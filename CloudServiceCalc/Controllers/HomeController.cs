using CloudServiceCalc.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CloudServiceCalc.Controllers
{
    public class HomeController : Controller
    {
        // GET: HomeController/Create
        public ActionResult CalculateServiceCost()
        {
            ViewBag.InstanceSize = new SelectList(CloudService.InstanceSizeDescriptions);
            return View(new CloudService() { NoInstances=2});
        }

        // POST: HomeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CalculateServiceCost(CloudService svc)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Confirm", svc);
            }
            else
            {
                ViewBag.InstanceSize = new SelectList(CloudService.InstanceSizeDescriptions);
                return View(new CloudService() { NoInstances = 2 });
            }
        }

        public ActionResult Confirm(CloudService svc)
        {
            return View(svc);
        }
        




        }
}
