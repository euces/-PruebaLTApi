using System;
using System.Collections.Generic;

#nullable disable

namespace Ventas.Model.Model
{
    public partial class Factura
    {
        public decimal Id { get; set; }
        public string Numerofactura { get; set; }
        public DateTime? Fecha { get; set; }
        public string Tipopago { get; set; }
        public string Documentocliente { get; set; }
        public string Nombrecliente { get; set; }
        public decimal Subtotal { get; set; }
        public decimal? Descuento { get; set; }
        public decimal Iva { get; set; }
        public decimal? Totaldescuento { get; set; }
        public decimal Totalimpuesto { get; set; }
        public decimal Total { get; set; }
        public decimal Productoid { get; set; }

        public virtual Producto Producto { get; set; }
    }
}
