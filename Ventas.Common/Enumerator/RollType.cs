using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Ventas.Common.Enumerator
{
    public enum RollType : Int32
    {
        [Description("Administrador")]
        Administrator = 1,

        [Description("Parceros")]
        Parceros = 2
    }
}