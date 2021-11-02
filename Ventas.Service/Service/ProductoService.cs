using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Ventas.Interface.Service;
using Ventas.Common.Utility;
using Ventas.Common.Dto;
using Ventas.Interface.Business;

namespace Ventas.Service.Service
{
    public class ProductoService : IProductoService
    {

        private readonly IProductoBusiness rearDerailleurTypeBusiness;

        public ProductoService(IProductoBusiness rearDerailleurTypeBusiness)
        {
            this.rearDerailleurTypeBusiness = rearDerailleurTypeBusiness;
        }

        public ResultDto<ProductoDto> GetAll()
        {
            var resultDto = this.rearDerailleurTypeBusiness.GetAll();
            return resultDto;
        }

        public ResultDto<ProductoDto> DeleteProducto(long id)
        {
            var resultDto = this.rearDerailleurTypeBusiness.DeleteProducto(id);
            return resultDto;
        }        

        public ResultDto<ProductoDto> GetProductoByIdActive(long id)
        {
            var resultDto = this.rearDerailleurTypeBusiness.GetProductoByIdActive(id);
            return resultDto;
        }

        public ResultDto<ProductoDto> SaveProducto(ProductoDto rearDerailleurType)
        {
            var resultDto = this.rearDerailleurTypeBusiness.SaveProducto(rearDerailleurType);
            return resultDto;
        }

        public ResultDto<ProductoDto> UpdateProducto(ProductoDto rearDerailleurType)
        {
            var resultDto = this.rearDerailleurTypeBusiness.UpdateProducto(rearDerailleurType);
            return resultDto;
        }

        public ResultDto<ProductoDto> GetAllByStatus()
        {
            var resultDto = this.rearDerailleurTypeBusiness.GetAllByStatus();
            return resultDto;
        }
    }
}
