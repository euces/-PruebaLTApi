using Newtonsoft.Json;
using Ventas.Common.Enumerator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ventas.Common.Utility
{
    [JsonObject(Title = "paginationDto")]
    public class PaginationDto
    {
        [JsonProperty(PropertyName = "pageNo")]
        public int PageNo { get; set; }

        [JsonProperty(PropertyName = "pageSize")]
        public int PageSize { get; set; }

        [JsonProperty(PropertyName = "order")]
        public OrderType Order { get; set; }

        [JsonProperty(PropertyName = "rowNumber")]
        public Int64 RowNumber { get; set; }

        [JsonProperty(PropertyName = "countRowNumber")]
        public bool CountRowNumber { get; set; }

    }
}
