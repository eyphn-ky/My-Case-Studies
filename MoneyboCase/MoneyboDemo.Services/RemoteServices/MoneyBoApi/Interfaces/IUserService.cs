using MoneyboDemo.Dto.GoRestAPIModels.RequestModel;
using MoneyboDemo.Dto.GoRestAPIModels.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyboDemo.Services.RemoteServices.MoneyBoApi.Interfaces
{
    public interface IUserService
    {
        public User GetUserById(int Id);
        public List<User> GetAll();
        public AddUserRequestModel AddUser(AddUserRequestModel userReq);
    }
}
