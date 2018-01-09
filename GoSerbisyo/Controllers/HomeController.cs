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
            TempData["ServiceId"] = ServiceId;
            var model = _serviceImages.GetServiceImages(ServiceId);
            ViewBag.Message = "My Service Images.";
            return PartialView(model);
            //return Json(model, JsonRequestBehavior.AllowGet);
        }

        /*[HttpGet]
        public ActionResult GetMyServiceImages(int ServiceId)
        {
            TempData["ServiceId"] = ServiceId;
            var model = _serviceImages.GetServiceImages(ServiceId);
            ViewBag.Message = "My Service Images.";
            return View(model);
        }*/

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult UploadServiceImage()
        {
            string _imgname = string.Empty;
            string _comPath = string.Empty;

            TempData.Keep("ServiceId");

            if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
            {
                var pic = System.Web.HttpContext.Current.Request.Files["MyImages"];
                if (pic.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(pic.FileName);
                    var _ext = Path.GetExtension(pic.FileName);

                    _imgname = Guid.NewGuid().ToString();
                    _comPath = string.Concat(Server.MapPath("/Uploads/ServiceImages/"), TempData["ServiceId"], "_", _imgname, _ext);
                    _imgname = string.Concat(TempData["ServiceId"], "_", _imgname, _ext);

                    ViewBag.Msg = _comPath;
                    var path = _comPath;

                    // Saving Image in Original Mode
                    pic.SaveAs(path);

                    // resizing image
                    MemoryStream ms = new MemoryStream();
                    WebImage img = new WebImage(_comPath);

                    if (img.Width > 200)
                        img.Resize(200, 200);
                    img.Save(_comPath);
                    // end resize
                }
            }
            return Json(Convert.ToString(_imgname), JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddNewServiceImage(ServiceImageViewModel model)
        {
            _serviceImages.UpsertServiceImage(model);
            return RedirectToAction("MyServiceImages", new { ServiceId = model.ServiceId });
        }

    }
}