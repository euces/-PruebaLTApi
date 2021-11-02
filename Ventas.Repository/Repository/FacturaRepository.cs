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
    public class FacturaRepository : IFacturaRepository
    {
        private IRepository<Factura, decimal> repository;
        public FacturaRepository(VentasContext context)
        {
            this.repository = new Repository<Factura, decimal>(context);
        }

        public List<Factura> GetAllByStatus()
        {
            List<Factura> workshopService = this.repository.List().ToList();
            return workshopService;
        }
        public List<Factura> GetAll()
        {
            List<Factura> workshopService = this.repository.List().ToList();
            return workshopService;
        }

        public Factura GetFacturaById(long id)
        {
            Factura workshopService = this.repository.List().Where(w => w.Id == id).FirstOrDefault();
            return workshopService;
        }

        public int DeleteFactura(Factura workshopService)
        {
            int workshopServiceDeleteOk = this.repository.Edit(workshopService);
            return workshopServiceDeleteOk;
        }

        public int UpdateFactura(Factura workshopService)
        {
            int workshopServiceDeleteOk = this.repository.Edit(workshopService);
            return workshopServiceDeleteOk;
        }

        public Factura SaveFactura(Factura workshopService)
        {
            Factura workshopServiceResult = this.repository.Add(workshopService);
            return workshopServiceResult;
        }
    }
}
