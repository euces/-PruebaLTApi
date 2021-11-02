using Ventas.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ventas.Interface.Repository
{
    public interface IProductoRepository
    {
        List<Producto> GetAllByStatus();

        List<Producto> GetAll();

        Producto GetProductoById(long id);     

        int DeleteProducto(Producto rearDerailleurType);

        int UpdateProducto(Producto rearDerailleurType);

        Producto SaveProducto(Producto rearDerailleurType);

    }
}
