using Microsoft.AspNetCore.Mvc;
using Ventas.Common.Dto;
using Ventas.Common.Utility;
using Ventas.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ventas.Api.Controllers
{
    [Route("Ventas/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private IProductoService rearDerailleurTypeService;

        public ProductoController(IProductoService rearDerailleurTypeService)
        {
            this.rearDerailleurTypeService = rearDerailleurTypeService;
        }

        // GET: api/<ProductoController>
        [HttpGet]
        public ResultDto<ProductoDto> Get()
        {
            var resutl = this.rearDerailleurTypeService.GetAllByStatus();
            return resutl;
        }

        // GET api/<ProductoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProductoController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProductoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
