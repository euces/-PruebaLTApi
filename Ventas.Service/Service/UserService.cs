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
    public class UserService : IUserService
    {

        private readonly IUserBusiness userBusiness;

        public UserService(IUserBusiness userBusiness)
        {
            this.userBusiness = userBusiness;
        }

        public ResultDto<UserDto> Authenticate(string userName, string password)
        {
            var resultDto = this.userBusiness.Authenticate(userName, password);
            return resultDto;
        }

        public ResultDto<UserDto> SaveUser(UserDto userDto)
        {
            var resultDto = this.userBusiness.SaveUser(userDto);
            return resultDto;
        }
    }
}
