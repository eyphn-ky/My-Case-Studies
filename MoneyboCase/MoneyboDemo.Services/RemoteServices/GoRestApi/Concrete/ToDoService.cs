using Microsoft.Extensions.Configuration;
using MoneyboDemo.Dto.GoRestAPIModels.RequestModel;
using MoneyboDemo.Dto.GoRestAPIModels.ResponseModel;
using MoneyboDemo.Model.Helpers;
using MoneyboDemo.Services.RemoteServices.GoRestApi.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyboDemo.Services.RemoteServices.GoRestApi.Concrete
{
    public class ToDoService : BaseService, IToDoService
    {
        private IConfiguration _configuration;
        private IRequestHelper _requestHelper;
        string baseUrl;
        string token;
        public ToDoService(IConfiguration configuration, IRequestHelper requestHelper) : base(configuration)
        {
            _configuration = configuration;
            baseUrl = _configuration.GetSection("GoRest:Url").Value+"todos";
            token = _configuration.GetSection("GoRest:Token").Value;
            _requestHelper = requestHelper;
        }

        public ToDo AddToDoWithUserId(ToDo todo)
        {
            var json = JsonConvert.SerializeObject(todo);
            var result = _requestHelper.PostByToken(baseUrl,json,token);
            if(result.IsSuccessStatusCode)
            {
                return todo;
            }
            return null;
        }
    }
}
