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
    public class FacturaService : IFacturaService
    {

        private readonly IFacturaBusiness facturaBusiness;

        public FacturaService(IFacturaBusiness facturaBusiness)
        {
            this.facturaBusiness = facturaBusiness;
        }

        public ResultDto<FacturaDto> GetAll()
        {
            var resultDto = this.facturaBusiness.GetAll();
            return resultDto;
        }

        public ResultDto<FacturaDto> DeleteFactura(long id)
        {
            var resultDto = this.facturaBusiness.DeleteFactura(id);
            return resultDto;
        }        

        public ResultDto<FacturaDto> GetFacturaByIdActive(long id)
        {
            var resultDto = this.facturaBusiness.GetFacturaByIdActive(id);
            return resultDto;
        }

        public ResultDto<FacturaDto> SaveFactura(FacturaDto factura)
        {
            var resultDto = this.facturaBusiness.SaveFactura(factura);
            return resultDto;
        }

        public ResultDto<FacturaDto> UpdateFactura(FacturaDto factura)
        {
            var resultDto = this.facturaBusiness.UpdateFactura(factura);
            return resultDto;
        }

        public ResultDto<FacturaDto> GetAllByStatus()
        {
            var resultDto = this.facturaBusiness.GetAllByStatus();
            return resultDto;
        }
    }
}
