using Ventas.Common.Dto;
using Ventas.Common.Utility;
using Ventas.Model.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ventas.Interface.Repository
{
    public interface IUserRepository
    {
        List<User> GetAll();

        List<User> SearchUserByName(string userName);

        int DeleteUser(User user);

        int UpdateUser(User user);

        User SaveUser(User user);

        List<User> SearchByNameAndPassword(string userName, string password);        
    }
}
