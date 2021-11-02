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
    public class LoginController : ControllerBase
    {
        private IUserService userService;

        public LoginController(IUserService userService)
        {
            this.userService = userService;           
        }

        // GET: api/<LoginController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<LoginController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
      
        [HttpPost]    
        public ResultDto<UserDto> Post([FromBody] UserDto model)
        {
            var result = userService.Authenticate(model.UserName, model.Password);
            return result;
        }

        // PUT api/<LoginController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LoginController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
