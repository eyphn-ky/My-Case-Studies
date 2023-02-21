using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmasiDemo.Models.Interface
{
    interface IDto
    {
        string Id { get; set; }
        DateTime CreatedOn { get; set; }
        DateTime? UpdatedOn { get; set; }
    }
}
