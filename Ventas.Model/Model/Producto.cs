using System;
using System.Collections.Generic;

#nullable disable

namespace Ventas.Model.Model
{
    public partial class Producto
    {
        public Producto()
        {
            Facturas = new HashSet<Factura>();
        }

        public decimal Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Factura> Facturas { get; set; }
    }
}
