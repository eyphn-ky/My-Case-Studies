using AutoMapper;
using FarmasiDemo.Entities.Concrete;
using FarmasiDemo.Models.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmasiDemo.Models.Mapper
{
    public class AutoMapping:Profile
    {
        public AutoMapping()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
        }
    }
}
