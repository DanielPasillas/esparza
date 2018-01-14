using AutoMapper;
using grupoesparza.Models;
using System;
using grupoesparza.Areas.Administrator.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace grupoesparza.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Mapping configuration.

            //User mapping.
            Mapper.CreateMap<Register, admin_user_table>();
            Mapper.CreateMap<Bases, bases>();
            Mapper.CreateMap<Grupos, grupos>();
            Mapper.CreateMap<Maderas, maderas>();
        }
    }
}