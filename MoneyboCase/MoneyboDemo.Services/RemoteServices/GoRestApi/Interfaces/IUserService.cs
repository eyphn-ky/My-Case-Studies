using MoneyboDemo.Dto.GoRestAPIModels.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyboDemo.Services.RemoteServices.GoRestApi.Interfaces
{
    public interface IUserService
    {
        public User GetUserById(int Id);
        public User AddUser(User user);
        public List<User> GetAll();

    }
}
