using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyboDemo.Dto.GoRestAPIModels.ResponseModel
{
    public class ToDo
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public string title { get; set; }
        public string due_on { get; set; }
        public string status { get; set; }
    }
}
