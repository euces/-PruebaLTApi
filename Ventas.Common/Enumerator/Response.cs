using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Ventas.Common.Enumerator
{
  public enum Response : Int32
  {
    [Description("OK")]
    OK = 200,

    [Description("FAIL")]
    FAIL = 500,

    [Description("FORBIDDEN")]
    Forbidden = 403,

    [Description("PROBLEMA_VALOR_REQUERIDO")]
    PROBLEMA_VALOR_REQUERIDO = 4,

    [Description("ENTIDAD_NO_ENCONTRADA")]
    ENTIDAD_NO_ENCONTRADA = 5,

    [Description("PROBLEMA_CONSUMO_SERVICIO")]
    PROBLEMA_CONSUMO_SERVICIO = 6

  }
}
