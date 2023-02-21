using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoneyboDemo.Dto.GoRestAPIModels.RequestModel;
using MoneyboDemo.Dto.GoRestAPIModels.ResponseModel;
using MoneyboDemo.Model.Enums;
using MoneyboDemo.Services.RemoteServices.GoRestApi.Interfaces;

namespace MoneyboDemo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IMapper _mapper;
        IUserService _userService;
        public UserController(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }
        [Route("adduser")]
        [HttpPost]
        public IActionResult AddUser(AddUserRequestModel userReq)
        {
            User user = _mapper.Map<User>(userReq);
            user.status = SetStateByGenderInfo(userReq);
            var result = _userService.AddUser(user);
            return Ok(result);
        }
        [Route("getuserbyid")]
        [HttpGet]
        public IActionResult GetUserById(int id)
        {
            User user = _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        [Route("getall")]
        [HttpGet]
        public IActionResult GetAll()
        {
            List<User> user = _userService.GetAll();
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        private string SetStateByGenderInfo(AddUserRequestModel userReq)
        {
            string state = "inactive";
            if (userReq.GenderNumber == (int)Gender.Male || userReq.GenderNumber == (int)Gender.Female)
            {
                state = "active";
            }
            return state;
        }
    }
}
