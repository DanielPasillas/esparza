using AutoMapper;
using grupoesparza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace grupoesparza.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Register, admin_user_table>();
        }
    }
}