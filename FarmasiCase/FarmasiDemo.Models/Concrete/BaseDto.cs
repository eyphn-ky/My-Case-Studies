
using FarmasiDemo.Models.Interface;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmasiDemo.Models.Concrete
{
    public class BaseDto : IDto
    {
        public string Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
