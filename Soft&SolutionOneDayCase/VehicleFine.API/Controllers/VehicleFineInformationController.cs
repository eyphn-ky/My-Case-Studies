using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleFine.BusinessLogic.Abstract;
using VehicleFine.Entities.Concrete;

namespace VehicleFine.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehicleFineInformationController : ControllerBase
    {
        IVehicleFineInformationService _vehicleInformationService;
        public VehicleFineInformationController(IVehicleFineInformationService vehicleFineInformationService)
        {
            _vehicleInformationService = vehicleFineInformationService;
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _vehicleInformationService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("GetVehicleFineByPlate")]
        public IActionResult GetVehicleFineByPlate(string plate)
        {
            var result = _vehicleInformationService.GetVehicleFineByPlate(plate);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("PayThePrice")]
        public IActionResult PayThePrice(int vehicleInformationId)
        {
            var result = _vehicleInformationService.PayThePrice(vehicleInformationId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        
    }
}


//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Logging;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using VehicleFine.Entities.Concrete;

//namespace VehicleFine.API.Controllers
//{
//    [ApiController]
//    [Route("[controller]")]
//    public class VehicleFineInformationController : ControllerBase
//    {

//        [HttpGet]
//        public IEnumerable<List<VehicleFineInformation>> Get()
//        {

//        }
//    }
//}
