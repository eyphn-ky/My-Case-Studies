using Microsoft.Extensions.Configuration;
using MoneyboDemo.Services.RemoteServices.GoRestApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyboDemo.Services.RemoteServices.MoneyBoApi.Concrete
{
    public class BaseService : IBaseService
    {
        IConfiguration _configuration;
        public BaseService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
    }
}
