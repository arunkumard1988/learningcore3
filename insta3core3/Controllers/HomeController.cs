using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using insta3core3.Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

namespace insta3core3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult TicketConfirmation(string usernamePassenger,string emailPassenger,string mobilePassenger,string addressPassenger,string traveDatePassenger,string traveTimePassenger,string driverDetails,string finalPrize)
        {
            var userinfo = new UserInfoViewModel();
            userinfo.UserName = usernamePassenger;
            userinfo.UserEmail = emailPassenger;
            userinfo.MobileNo = mobilePassenger;
            userinfo.UserAddress = addressPassenger;
            userinfo.TravelDate = traveDatePassenger;
            userinfo.TravelTime = traveTimePassenger;
            userinfo.DriverName = driverDetails;
            userinfo.FinalPrice = finalPrize;
            //HttpContext.Session.SetString("UserAddress", addressPassenger);
            //HttpContext.Session.SetString("driverDetails", driverDetails);
            return View("PaymentGateway", userinfo);
            //return View("TicketConfirmation",userinfo);
        }

        [HttpGet]
        public IActionResult Booking(string driverName,string rateperKm, string travelDate,string destination,string totalKm)
        {
            var rate = Convert.ToInt32(rateperKm) * Convert.ToInt32(totalKm);
            var proj = new DriverInfoViewModel();
            proj.DriverName = driverName;
            proj.Price = rate.ToString();
            proj.RatePerKm = rateperKm.ToString();
            ViewData["destination"] = destination;
            ViewData["travelDate"] = travelDate;
            return View("Booking",proj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ListingCar(string sourceVal,string destinationVal,string dateVal,int distanceVal)
        {
            try
            {
              string jsonDriverData = @"[
                                        {
                                          'name': 'Amit',
                                          'language': 'Hindi',
                                          'carName': 'Etios',
                                          'rateperKm': 15
                                        },
                                        {
                                          'name': 'Justin',
                                          'language': 'Kannada',
                                          'carName': 'Etios',
                                          'rateperKm': 18
                                        },
                                        {
                                          'name': 'Putin',
                                          'language': 'English',
                                          'carName': 'Etios',
                                          'rateperKm': 20
                                        }
                                      ]";

                dynamic driverObj = JsonConvert.DeserializeObject(jsonDriverData);
                var driverList = new List<DriverInfoViewModel>();
                //dynamic alertObj1 = JsonConvert.DeserializeObject(data);
                foreach (var driverInfo in driverObj)
                {
                    //int ratekm = driverInfo.rateperKm != null ? Convert.ToInt32(driverInfo.rateperKm) : 0;
                    var rate = driverInfo.rateperKm;
                    var proj = new DriverInfoViewModel();
                    proj.DriverName = driverInfo.name;
                    proj.CarName = driverInfo.carName;
                    proj.Language = driverInfo.language;
                    proj.Price = rate * distanceVal;
                    proj.RatePerKm = driverInfo.rateperKm;
                    driverList.Add(proj);
                }
               // return View();
               ViewData["distanceValue"]= distanceVal;
                ViewData["destination"] = destinationVal;
                ViewData["travelDate"] = dateVal;
                return PartialView("Listing", driverList);
            }
            catch(Exception e)
            {
                return View();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult SuccessBooking()
        {
            var userinfo = new UserInfoViewModel();
            userinfo.UserName = HttpContext.Session.GetString("driverDetails");
            userinfo.UserEmail = HttpContext.Session.GetString("driverDetails");
            userinfo.MobileNo = HttpContext.Session.GetString("driverDetails");
            userinfo.UserAddress = HttpContext.Session.GetString("UserAddress");
            userinfo.TravelDate = HttpContext.Session.GetString("driverDetails");
            userinfo.TravelTime = HttpContext.Session.GetString("driverDetails");
            userinfo.DriverName = HttpContext.Session.GetString("driverDetails");
            userinfo.FinalPrice = HttpContext.Session.GetString("driverDetails");  
            return View("TicketConfirmation", userinfo);
        }

        [HttpGet]
        public IActionResult PaymentFailure()
        {
            return View("PaymentFailure");
        }
    }
}
