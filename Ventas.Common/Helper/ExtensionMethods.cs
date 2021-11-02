using Ventas.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ventas.Common.Helper
{
    public static class ExtensionMethods
    {
        public static IEnumerable<UserDto> WithoutPasswords(this IEnumerable<UserDto> users)
        {
            return users.Select(x => x.WithoutPassword());
        }

        public static UserDto WithoutPassword(this UserDto user)
        {
            user.Password = null;
            return user;
        }
    }
}
