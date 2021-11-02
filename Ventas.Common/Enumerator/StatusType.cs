using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Ventas.Common.Enumerator
{
    public enum StatusType : Int32
    {
        [Description("Activo")]
        Active = 1,
        [Description("Inactivo")]
        Inactive = 2,

    }
}
