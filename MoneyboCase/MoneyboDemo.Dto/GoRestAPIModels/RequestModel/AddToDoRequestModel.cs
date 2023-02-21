using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyboDemo.Dto.GoRestAPIModels.RequestModel
{
    public class AddToDoRequestModel
    {
        public string user_id { get; set; }
        public string title { get; set; }
        public string due_on { get;set; }
        public string status { get; set; }
    }
}
