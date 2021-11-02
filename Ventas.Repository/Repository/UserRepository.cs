using Ventas.Common.Enumerator;
using Ventas.Common.Utility;
using Ventas.Infrastructure.Repository;
using Ventas.Interface.Repository;
using Ventas.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ventas.Repository.Repository
{
    public class UserRepository : IUserRepository
    {
        private IRepository<User, decimal> repository;
        public UserRepository(VentasContext context)
        {
            this.repository = new Repository<User, decimal>(context);
        }
        public List<User> GetAll()
        {
            List<User> users = this.repository.List().ToList();
            return users;
        }

        public List<User> SearchUserByName(string userName)
        {

            List<User> users = this.repository.List().Where(w => w.UserName == userName).ToList();
            return users;
        }

        public int DeleteUser(User user)
        {
            int userDeleteOk = this.repository.Edit(user);
            return userDeleteOk;
        }

        public int UpdateUser(User user)
        {
            int userDeleteOk = this.repository.Edit(user);
            return userDeleteOk;
        }

        public User SaveUser(User user)
        {
            User userResult = this.repository.Add(user);
            return userResult;
        }

        public List<User> SearchByNameAndPassword(string userName, string password)
        {
            List<User> users = null;
            if (userName == "eulices" && password == "Admin123")
            {
                users = new List<User>()
                 {
                     new User()
                     {
                         UserName="eulices",
                         Password ="Admin123"
                     }
                 };
            }
            
            return users;
        }
    }
}
