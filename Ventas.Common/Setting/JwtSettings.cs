using System;
using System.Collections.Generic;
using System.Text;

namespace Ventas.Common.Setting
{
  public class JwtSettings
  {
    public string Secret { get; set; }

    public string ValidIssuer { get; set; }

    public string ValidAudience { get; set; }
  }
}
