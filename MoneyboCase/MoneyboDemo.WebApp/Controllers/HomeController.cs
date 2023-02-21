using Microsoft.AspNetCore.Mvc;
using MoneyboDemo.Dto.GoRestAPIModels.ResponseModel;
using MoneyboDemo.Dto.GoRestAPIModels.RequestModel;

using MoneyboDemo.WebApp.Models;
using System.Diagnostics;
using AutoMapper;
using MoneyboDemo.Model.Enums;
using MoneyboDemo.Services.RemoteServices.MoneyBoApi.Interfaces;

namespace MoneyboDemo.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IMapper _mapper;
        private IUserService _userService;
        private IToDoService _todoService;
        public HomeController(ILogger<HomeController> logger, IMapper mapper,IUserService userService, IToDoService todoService)
        {
            _logger = logger;
            _mapper = mapper;
            _userService = userService;
            _todoService = todoService;
        }

        public IActionResult Users()
        {
            return View();
        }

        public IActionResult AddUserAjaxPop(AddUserRequestModel userRequestModel)
        {
            var result=_userService.AddUser(userRequestModel);
            if(result!=null)
            {
                return Json(new { success = true });
            }
            return Json(new { success = false });

        }
        public IActionResult GetUserListAjaxPop()
        {
            var result = _userService.GetAll();
            if(result!=null)
            {
                return Json(new { success = true, data = result });
            }
            return Json(new { success = false });
        }

        public IActionResult AddToDoToUserAjaxPop(AddToDoRequestModel addToDoRequestModel)
        {
            var result = _todoService.AddToDoWithUserId(addToDoRequestModel);
            return Json(new { success = true });

        }
        public IActionResult UserWithId()
        {
            return View();
        }
        public IActionResult UserWithIdAjaxPop(int Id)
        {
            var result = _userService.GetUserById(Id);
            if(result!=null)
            {
                return Json(new { success = true,data=result });
            }
            return Json(new { success = false });

        }
    }
}