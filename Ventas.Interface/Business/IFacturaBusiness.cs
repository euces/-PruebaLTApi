using Ventas.Common.Dto;
using Ventas.Common.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ventas.Interface.Business
{
    public interface IFacturaBusiness
    {
        ResultDto<FacturaDto> GetAllByStatus();
        ResultDto<FacturaDto> GetAll();

        ResultDto<FacturaDto> GetFacturaByIdActive(long id);

        ResultDto<FacturaDto> DeleteFactura(long id);

        ResultDto<FacturaDto> UpdateFactura(FacturaDto factura);

        ResultDto<FacturaDto> SaveFactura(FacturaDto factura);        
    }
}
