using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ventas.Common.Utility
{
    [Serializable]
    [JsonObject(Title = "resultDto")]
    public class ResultDto<T>
    {
        [JsonProperty(PropertyName = "responseDto")]
        public ResponseDto ResponseDto { get; set; }

        [JsonProperty(PropertyName = "paginationDto")]
        public PaginationDto PaginationDto { get; set; }

        [JsonProperty(PropertyName = "businessDto")]
        public List<T> BusinessDto { get; set; }
    }
}
