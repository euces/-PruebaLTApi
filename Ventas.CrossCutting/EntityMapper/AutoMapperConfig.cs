using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace Ventas.CrossCutting.EntityMapper
{
    public static class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            var config = new MapperConfiguration(x =>
            {
                x.AddProfile<MapperDtoToModel>();
                x.AddProfile<MapperModelToDto>();
            });
        }
    }
}
