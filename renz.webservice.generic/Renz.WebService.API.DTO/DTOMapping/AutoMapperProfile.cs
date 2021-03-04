using AutoMapper;
using RivTech.WebService.Generic.Data.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RivTech.WebService.Generic.DTO.DTOMapping
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<LvWeight, WeightDTO>().ReverseMap();
            CreateMap<LvItem, ItemDTO>().ReverseMap();
        }
    }
}
