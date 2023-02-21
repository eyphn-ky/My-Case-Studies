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
    public class UserService : BaseService, IUserService
    {
        private IConfiguration _configuration;
        private IRequestHelper _requestHelper;
        private string baseUrl;
        public UserService(IConfiguration configuration,IRequestHelper requestHelper) : base(configuration)
        {
            _configuration= configuration;
            _requestHelper= requestHelper;
            baseUrl = _configuration.GetSection("MoneyboApi:Url").Value+"user/";
        }
        public AddUserRequestModel AddUser(AddUserRequestModel userReq)
        {
            try
            {
                var result = _requestHelper.Post(baseUrl + "adduser", JsonConvert.SerializeObject(userReq));
                return userReq;
            }
            catch(Exception ex) {
                throw ex;
            }
        }

        public User GetUserById(int Id)
        {
            var url = baseUrl + "getuserbyid?id=" + Id;
            var result = _requestHelper.Get(url);
            return JsonConvert.DeserializeObject<User>(result);
        }

        public List<User> GetAll()
        {
            var url = baseUrl + "getall";
            var result = _requestHelper.Get(url);
            return JsonConvert.DeserializeObject<List<User>>(result);
        }
    }
}
