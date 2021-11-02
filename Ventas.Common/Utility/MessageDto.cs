using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ventas.Common.Utility
{
    public class MessageDto
    {
        public List<MailboxAddress> To { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }

        public MessageDto(IEnumerable<string> to, string subject, string content)
        {
            To = new List<MailboxAddress>();

            To.AddRange(to.Select(x =>
            {
                return new MailboxAddress(x);
            }));

            Subject = subject;
            Content = content;
        }
    }
}
