using System;
using System.Collections.Generic;
using System.Text;

namespace Ventas.Model.Base
{
    public abstract class EntityBase<U>
    {
        public U Id { get; set; }
    }
}
