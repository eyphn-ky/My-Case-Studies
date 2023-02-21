using Microsoft.Extensions.Configuration;
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
    public class UserService : BaseService, IUserService
    {
        private IConfiguration _configuration;
        private IRequestHelper _requestHelper;
        private string baseUrl;
        private string token;
        public UserService(IConfiguration configuration,IRequestHelper requestHelper):base(configuration)
        {
            _configuration= configuration;
            _requestHelper= requestHelper;
            baseUrl = configuration.GetSection("GoRest:Url").Value+"users";
            token = configuration.GetSection("GoRest:Token").Value;
        }

        public User AddUser(User user)
        {
            var json = JsonConvert.SerializeObject(user);
            var result = _requestHelper.PostByToken(baseUrl,json,token);
            if(result.IsSuccessStatusCode)
            {
                return user;
            }
            return null;
        }

        public User GetUserById(int Id)
        {
            try
            {
                var response = _requestHelper.GetByToken(baseUrl + "?id=" + Id, token);
                var result = JsonConvert.DeserializeObject<List<User>>(response).First();
                return result;
            }
            catch (Exception ex) {
                throw ex;
            }
        }
        public List<User> GetAll()
        {
            try
            {
                var response = _requestHelper.GetByToken(baseUrl, token);
                var result = JsonConvert.DeserializeObject<List<User>>(response);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
