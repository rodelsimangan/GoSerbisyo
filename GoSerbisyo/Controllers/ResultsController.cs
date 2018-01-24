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
        readonly IServiceRatingsAppService _ratings;
        readonly IServiceReportsAppService _report;
        readonly IGoSerbisyoDBContext _context;

        public ResultsController()
        {
            _context = new GoSerbisyoDBContext();
            _services = new ServicesAppService(_context);
            _serviceImages = new ServiceImagesAppService(_context);
            _membership = new MembershipAppService();
            _ratings = new ServiceRatingsAppService(_context);
            _report = new ServiceReportsAppService(_context);
        }

        public ActionResult Index(string name, string location)
        {
            List<ServiceModel> model = _services.GetServices(name, location);
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
            ServiceModel model = new ServiceModel();
            ViewBag.Message = "My Service Images.";
            return Json(model);
        }

        public ActionResult Details(int s)
        {
            ResultModel model = new ResultModel();
            var service = _services.GetService(s);
            var user = _membership.GetUser(service.UserId);
            var ratings = _ratings.GetServiceRatings(s);

            var loginId = _membership.GetUserId(User.Identity.Name);

            if (service!=null && user !=null)
            {
                model.ServiceId = service.Id;
                model.ServiceName = service.Name;
                model.ServiceDescription = service.Description;
                model.ServiceLocation = service.Location;
                model.ServiceLinkToProfile = service.LinkToProfile;
                model.ServiceSendToMessenger = service.SendToMessenger;

                model.UserId = user.Id;
                model.UserName = user.Name;
                model.UserLocation = user.Location;
                model.UserContactNumber = user.ContactNumber;
                model.UserNameIdentifier = user.NameIdentifier;

                model.PositiveRatings = ratings.Where(r => r.Rating == true).Count();
                model.NegativeRatings = ratings.Where(r => r.Rating == false).Count();
                var hasRatings = ratings.Where(r => r.LoginId == loginId).Count();
                if (hasRatings > 0)
                    model.RatingGiven = true;

                model.LoginId = loginId;
            }
            return View(model);
        }

        public ActionResult RateService(RatingModel model)
        {
            _ratings.UpsertServiceRating(model);
            return RedirectToAction("Details", new { s = model.ServiceId });
        }

        public ActionResult ReportService(ReportModel model)
        {
            _report.UpsertServiceReport(model);
            return RedirectToAction("Details", new { s = model.ServiceId });
        }
    }
}