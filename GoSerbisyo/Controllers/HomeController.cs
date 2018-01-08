using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

using GoSerbisyo.Models;
using GoSerbisyo.AppServices;

namespace GoSerbisyo.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        readonly IServicesAppService _services;
        readonly IServiceImagesAppService _serviceImages;
        readonly IMembershipAppService _membership;
        readonly IGoSerbisyoDBContext _context;

        public HomeController()
        {
            _context = new GoSerbisyoDBContext();
            _services = new ServicesAppService(_context);
            _serviceImages = new ServiceImagesAppService(_context);
            _membership = new MembershipAppService();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult MyServices()
        {
            ViewBag.Message = "My Services.";
            var userId = _membership.GetUserId(User.Identity.Name);
            List<ServiceViewModel> model = _services.GetServices(userId);
            return View(model);
        }

        public ActionResult AddNewService(ServiceViewModel model)
        {
            _services.UpsertService(model);
            return RedirectToAction("MyServices");
        }

        [HttpGet]
        public JsonResult GetMyService(int ServiceId)
        {
            var model = _services.GetService(ServiceId);
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        
        public PartialViewResult MyServiceImages(int ServiceId)
        {
            ViewData["ServiceId"] = ServiceId;
            var model = _serviceImages.GetServiceImages(ServiceId);
            ViewBag.Message = "My Service Images.";
            return PartialView(model);
            //return Json(model, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetMyServiceImages(int ServiceId)
        {
            ViewData["ServiceId"] = ServiceId;
            var model = _serviceImages.GetServiceImages(ServiceId);
            ViewBag.Message = "My Service Images.";
            return View(model);
        }

    }
}