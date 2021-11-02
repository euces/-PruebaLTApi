using Ventas.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ventas.Interface.Repository
{
    public interface IFacturaRepository
    {
        List<Factura> GetAllByStatus();

        List<Factura> GetAll();

        Factura GetFacturaById(long id);     

        int DeleteFactura(Factura factura);

        int UpdateFactura(Factura factura);

        Factura SaveFactura(Factura factura);

    }
}
