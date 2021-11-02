using Ventas.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ventas.Model.Model
{
    public partial class User : EntityBase<decimal>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
