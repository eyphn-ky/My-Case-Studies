using Microsoft.Extensions.Configuration;
using MoneyboDemo.Dto.GoRestAPIModels.RequestModel;
using MoneyboDemo.Dto.GoRestAPIModels.ResponseModel;
using MoneyboDemo.Model.Helpers;
using MoneyboDemo.Services.RemoteServices.MoneyBoApi.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyboDemo.Services.RemoteServices.MoneyBoApi.Concrete
{
    public class ToDoService : BaseService, IToDoService
    {
        IConfiguration _configuration;
        IRequestHelper _requestHelper;
        string baseUrl;
        public ToDoService(IConfiguration configuration, IRequestHelper requestHelper) : base(configuration)
        {
            _configuration = configuration;
            baseUrl = _configuration.GetSection("MoneyboApi:Url").Value + "todo/";
            _requestHelper = requestHelper;
        }
        public AddToDoRequestModel AddToDoWithUserId(AddToDoRequestModel todo)
        {
            todo.due_on = DateTime.Now.ToString();
            string url = baseUrl + "addtodotouser";
            var json = JsonConvert.SerializeObject(todo);
            var result = _requestHelper.Post(url,json);
            return todo;
        }
    }
}
