using Ventas.Common.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ventas.Interface.Helpeer
{
    public interface IEmailSenderHelper
    {
        void SendEmail(MessageDto message);
    }
}
