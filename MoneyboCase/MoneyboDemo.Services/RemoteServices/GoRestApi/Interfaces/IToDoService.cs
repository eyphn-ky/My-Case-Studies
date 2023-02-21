using MoneyboDemo.Dto.GoRestAPIModels.RequestModel;
using MoneyboDemo.Dto.GoRestAPIModels.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyboDemo.Services.RemoteServices.GoRestApi.Interfaces
{
    public interface IToDoService
    {
        public ToDo AddToDoWithUserId(ToDo todo);
    }
}
