using AutoMapper;
using Ventas.Common.Dto;
using Ventas.Model.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ventas.CrossCutting.EntityMapper
{
    public class MapperDtoToModel : Profile
    {
        public MapperDtoToModel()
        {
            CreateMap<UserDto, User>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id));

            CreateMap<FacturaDto, Factura>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Numerofactura, y => y.MapFrom(z => z.Numerofactura))
                .ForMember(x => x.Fecha, y => y.MapFrom(z => z.Fecha))
                .ForMember(x => x.Tipopago, y => y.MapFrom(z => z.Tipopago))
                .ForMember(x => x.Documentocliente, y => y.MapFrom(z => z.Documentocliente))
                .ForMember(x => x.Nombrecliente, y => y.MapFrom(z => z.Nombrecliente))
                .ForMember(x => x.Subtotal, y => y.MapFrom(z => z.Subtotal))
                .ForMember(x => x.Descuento, y => y.MapFrom(z => z.Descuento))
                .ForMember(x => x.Iva, y => y.MapFrom(z => z.Iva))
                .ForMember(x => x.Totaldescuento, y => y.MapFrom(z => z.Totaldescuento))
                .ForMember(x => x.Totalimpuesto, y => y.MapFrom(z => z.Totalimpuesto))
                .ForMember(x => x.Total, y => y.MapFrom(z => z.Total))
                .ForMember(x => x.Producto, y => y.MapFrom(z => z.Producto));


            CreateMap<ProductoDto, Producto>()
               .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
               .ForMember(x => x.Nombre, y => y.MapFrom(z => z.Nombre));

        }
    }
}
