using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MoneyboDemo.Dto.GoRestAPIModels.RequestModel;
using MoneyboDemo.Dto.GoRestAPIModels.ResponseModel;
using MoneyboDemo.Model.Enums;

namespace MoneyboDemo.Dto.Mapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<AddUserRequestModel, User>().ForMember(req=>req.gender,user=>user.MapFrom(src=>src.GenderNumber!=0?Enum.GetName(typeof(Gender),src.GenderNumber).ToLower():""));
            CreateMap<User, AddUserRequestModel>();
            CreateMap<AddToDoRequestModel, ToDo>().ReverseMap();
        }
    }
}
