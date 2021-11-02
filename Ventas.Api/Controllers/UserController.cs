using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Ventas.Common.Dto;
using Ventas.Common.Enumerator;
using Ventas.Common.Helper;
using Ventas.Common.Setting;
using Ventas.Common.Utility;
using Ventas.Interface.Helpeer;
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
    public class UserController : ControllerBase
    {
        private IUserService userService;
        private IEmailSenderHelper emailSenderHelper;
        private ITokenHelper tokenHelper;

        public UserController(IUserService userService, IEmailSenderHelper emailSenderHelper, ITokenHelper tokenHelper)
        {
            this.userService = userService;
            this.emailSenderHelper = emailSenderHelper;
            this.tokenHelper = tokenHelper;
        }

        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public ResultDto<UserDto> Post([FromBody] UserDto userDto)
        {
            PasswordHelper passwordHelper = new PasswordHelper();

            userDto.RollId = RollType.Parceros.GetHashCode();
            userDto.StatusId = StatusType.Active.GetHashCode();

            userDto.PasswordDefault = passwordHelper.GeneratePassword(true, true, true, true, 6);
            ResultDto<UserDto> result = this.userService.SaveUser(userDto);

            
            return result;
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
