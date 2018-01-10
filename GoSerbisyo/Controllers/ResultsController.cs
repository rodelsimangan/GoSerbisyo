using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

using GoSerbisyo.Models;
using GoSerbisyo.AppServices;
using System.IO;
using System.Web.Helpers;

namespace GoSerbisyo.Controllers
{
    [RequireHttps]
    public class ResultsController : Controller
    {
        readonly IServicesAppService _services;
        readonly IServiceImagesAppService _serviceImages;
        readonly IMembershipAppService _membership;
        readonly IGoSerbisyoDBContext _context;

        public ResultsController()
        {
            _context = new GoSerbisyoDBContext();
            _services = new ServicesAppService(_context);
            _serviceImages = new ServiceImagesAppService(_context);
            _membership = new MembershipAppService();
        }

        public ActionResult Index(string name, string location)
        {
            List<ServiceViewModel> model = _services.GetServices(name, location);
            ViewBag.Message = string.Format("{0} Result(s) for {1}", model.Count(), name);
            return View(model);
        }

        public JsonResult GetMyFirstServiceImage(int ServiceId)
        {
            var list = _serviceImages.GetServiceImages(ServiceId);
            var model = list.FirstOrDefault();
            return Json(Convert.ToString(model.ImagePath), JsonRequestBehavior.AllowGet);
        }
      
        [HttpGet]
        public PartialViewResult DisplayServiceImages(int ServiceId)
        {
           // int ServiceId = int.Parse(TempData["ServiceId"].ToString());
            var model = _serviceImages.GetServiceImages(ServiceId);
            ViewBag.Message = "My Service Images.";
            return PartialView(model);
        }

        [HttpGet]
        public JsonResult Search()
        {
            ServiceViewModel model = new ServiceViewModel();
            ViewBag.Message = "My Service Images.";
            return Json(model);
        }
    }
}