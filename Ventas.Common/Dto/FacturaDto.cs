using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ventas.Common.Dto
{
    [JsonObject(Title = "facturaDto")]
    public class FacturaDto
    {

        [JsonProperty(PropertyName = "id")]
        public long Id { get; set; }
        [JsonProperty(PropertyName = "numeroFactura")]
        public string Numerofactura { get; set; }
        [JsonProperty(PropertyName = "fecha")]
        public DateTime? Fecha { get; set; }
        [JsonProperty(PropertyName = "tipopago")]
        public string Tipopago { get; set; }
        [JsonProperty(PropertyName = "documentoCliente")]
        public string Documentocliente { get; set; }
        [JsonProperty(PropertyName = "nombreCliente")]
        public string Nombrecliente { get; set; }
        [JsonProperty(PropertyName = "subtotal")]
        public decimal Subtotal { get; set; }
        [JsonProperty(PropertyName = "descuento")]
        public decimal Descuento { get; set; }
        [JsonProperty(PropertyName = "iva")]
        public decimal Iva { get; set; }
        [JsonProperty(PropertyName = "totalDescuento")]
        public decimal Totaldescuento { get; set; }
        [JsonProperty(PropertyName = "totalImpuesto")]
        public decimal Totalimpuesto { get; set; }
        [JsonProperty(PropertyName = "total")]
        public decimal Total { get; set; }
        [JsonProperty(PropertyName = "producto")]
        public decimal Producto { get; set; }
    }
}
