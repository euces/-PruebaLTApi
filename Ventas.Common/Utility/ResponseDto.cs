using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ventas.Common.Utility
{
    [JsonObject(Title = "responseDto")]
    public class ResponseDto
    {
        [JsonProperty(PropertyName = "response")]
        public string Response { get; set; }

        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }
    }
}
