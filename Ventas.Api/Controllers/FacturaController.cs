using Microsoft.AspNetCore.Mvc;
using Ventas.Common.Dto;
using Ventas.Common.Utility;
using Ventas.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ventas.Api.Controllers
{
    [Route("Ventas/[controller]")]
    [ApiController]
    [Authorize]
    public class FacturaController : ControllerBase
    {
        private IFacturaService workshopServiceService;

        public FacturaController(IFacturaService workshopServiceService)
        {
            this.workshopServiceService = workshopServiceService;
        }

        // GET: api/<FacturaController>
        [HttpGet]
        public ResultDto<FacturaDto> Get()
        {
            var resutl = this.workshopServiceService.GetAllByStatus();
            return resutl;
        }

        // GET api/<FacturaController>/5
        [HttpGet("{id}")]
        public ResultDto<FacturaDto> Get(long id)
        {
            var resutl = this.workshopServiceService.GetFacturaByIdActive(id);
            return resutl;
        }

        // POST api/<FacturaController>
        [HttpPost]
        public ResultDto<FacturaDto> Post([FromBody] FacturaDto factura)
        {
            var resutl = this.workshopServiceService.SaveFactura(factura);
            return resutl;
        }

        // PUT api/<FacturaController>
        [HttpPut("{id}")]
        public ResultDto<FacturaDto> Put([FromBody] FacturaDto factura)
        {
            var resutl = this.workshopServiceService.UpdateFactura(factura);
            return resutl;
        }

        // DELETE api/<FacturaController>/5
        [HttpDelete("{id}")]
        public ResultDto<FacturaDto> Delete(long id)
        {
            var resutl = this.workshopServiceService.DeleteFactura(id);
            return resutl;
        }
    }
}
