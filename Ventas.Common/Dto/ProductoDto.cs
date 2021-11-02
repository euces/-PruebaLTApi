using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ventas.Common.Dto
{
    [JsonObject(Title = "productoDto")]
    public class ProductoDto
    {

        [JsonProperty(PropertyName = "id")]
        public long Id { get; set; }

        [JsonProperty(PropertyName = "nombre")]
        public string Nombre { get; set; }
    }
}
