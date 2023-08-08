using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using VehicleFine.Core.Utilities.Requests;
using VehicleFine.Core.Utilities.Results;
using VehicleFine.Entities.Concrete;
using VehicleFine.WebApp.Models;

namespace VehicleFine.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private IRequestHelper _requestHelper;
        public HomeController(IRequestHelper requestHelper)
        {
            _requestHelper = requestHelper;
        }

        public IActionResult Index()
        {
            return View();
        }

        public string GetVehicleFineByPlate(string plate)
        {
            var result = _requestHelper.Get("https://localhost:44338/api/VehicleFineInformation/GetVehicleFineByPlate?plate=" + plate);
            return result;
        }
        public string GetAllVehicleFine()
        {
            var result = _requestHelper.Get("https://localhost:44338/api/VehicleFineInformation/GetAll");
            return result;
        }

        public string PayThePrice(int id)
        {
            var result =_requestHelper.Get("https://localhost:44338/api/VehicleFineInformation/PayThePrice?vehicleInformationId="+id);
            return result;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
