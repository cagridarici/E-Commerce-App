using E_Commerce.Domain.Entities;
using E_Commerce.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application
{
    public class InvoiceAppService : CrudAppServiceBase<Invoice>
    {
        private ApplicationRepository<Invoice> _InvoiceRepository = null;

        public InvoiceAppService(ApplicationRepository<Invoice> invoiceRepository) : base(invoiceRepository)
        {
            _InvoiceRepository = invoiceRepository;
        }

        public int Aynimi { get; set; }

        //// Custom Service Operations Here...
    
    }
}
