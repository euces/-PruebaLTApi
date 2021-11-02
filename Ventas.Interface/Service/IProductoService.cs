using Ventas.Common.Dto;
using Ventas.Common.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ventas.Interface.Service
{
    public interface IProductoService
    {
        ResultDto<ProductoDto> GetAllByStatus();

        ResultDto<ProductoDto> GetAll();

        ResultDto<ProductoDto> GetProductoByIdActive(long id);

        ResultDto<ProductoDto> DeleteProducto(long id);

        ResultDto<ProductoDto> UpdateProducto(ProductoDto rearDerailleurType);

        ResultDto<ProductoDto> SaveProducto(ProductoDto rearDerailleurType);
        
    }
}
