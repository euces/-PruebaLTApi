using Ventas.Infrastructure.Repository;
using Ventas.Interface.Repository;
using Ventas.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ventas.Repository.Repository
{
    public class ProductoRepository : IProductoRepository
    {
        private IRepository<Producto, decimal> repository;
        public ProductoRepository(VentasContext context)
        {
            this.repository = new Repository<Producto, decimal>(context);
        }

        public List<Producto> GetAllByStatus()
        {
            List<Producto> rearDerailleurType = this.repository.List().ToList();
            return rearDerailleurType;
        }
        public List<Producto> GetAll()
        {
            List<Producto> rearDerailleurType = this.repository.List().ToList();
            return rearDerailleurType;
        }

        public Producto GetProductoById(long id)
        {
            Producto rearDerailleurType = this.repository.List().Where(w => w.Id == id).FirstOrDefault();
            return rearDerailleurType;
        }

        public int DeleteProducto(Producto rearDerailleurType)
        {
            int rearDerailleurTypeDeleteOk = this.repository.Edit(rearDerailleurType);
            return rearDerailleurTypeDeleteOk;
        }

        public int UpdateProducto(Producto rearDerailleurType)
        {
            int rearDerailleurTypeDeleteOk = this.repository.Edit(rearDerailleurType);
            return rearDerailleurTypeDeleteOk;
        }

        public Producto SaveProducto(Producto rearDerailleurType)
        {
            Producto rearDerailleurTypeResult = this.repository.Add(rearDerailleurType);
            return rearDerailleurTypeResult;
        }
    }
}
