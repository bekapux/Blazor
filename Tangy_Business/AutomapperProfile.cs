using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tangy_DataAccess;
using Tangy_Models;

namespace Tangy_Business
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
        }
    }
}
