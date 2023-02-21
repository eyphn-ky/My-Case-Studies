using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoneyboDemo.Dto.GoRestAPIModels.RequestModel;
using MoneyboDemo.Dto.GoRestAPIModels.ResponseModel;
using MoneyboDemo.Services.RemoteServices.GoRestApi.Concrete;
using MoneyboDemo.Services.RemoteServices.GoRestApi.Interfaces;

namespace MoneyboDemo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        IMapper _mapper;
        IToDoService _toDoService;
        public ToDoController(IMapper mapper, IToDoService toDoService)
        {
            _mapper = mapper;
            _toDoService = toDoService;
        }

        [Route("addtodotouser")]
        [HttpPost]
        public IActionResult AddToDoToUser(AddToDoRequestModel todoReq)
        {
            ToDo toDo = _mapper.Map<ToDo>(todoReq);
            var result = _toDoService.AddToDoWithUserId(toDo);
            if(result==null)
            {
                return BadRequest();
            }
            return Ok(result);
        }

    }
}
