using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Ventas.Common.Enumerator
{
  public enum OrderType
  {
    [Description("ASC")]
    Descdescending = 0,

    [Description("DESC")]
    Ascending = 1
  }
}
