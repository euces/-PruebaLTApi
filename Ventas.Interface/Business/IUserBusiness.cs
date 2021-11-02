using Ventas.Common.Dto;
using Ventas.Common.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ventas.Interface.Business
{
    public interface IUserBusiness
    {
        ResultDto<UserDto> Authenticate(string userName, string password);
        ResultDto<UserDto> SaveUser(UserDto userDto);
    }
}
