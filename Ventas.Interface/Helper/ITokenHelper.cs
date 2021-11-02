using System;
using System.Collections.Generic;
using System.Text;

namespace Ventas.Interface.Service
{
  public interface ITokenHelper
  {
    string GetToken(int expirationDays, string userName);
    bool ValidateCurrentToken(string token);
  }
}
