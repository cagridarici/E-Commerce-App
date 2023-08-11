using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Entities
{
    public class Invoice : EntityBase
    {
        [Column("i_orderid")]
        public int OrderId
        {
            get;
            set;
        }


        [Column("i_invoicenumber")]
        public Guid InvoiceNumber
        {
            get;
            set;
        }

        [Column("i_invoicedate")]
        public DateTime InvoiceDateUtc
        {
            get;
            set;
        }

        [ForeignKey(nameof(OrderId))]
        public virtual Order Order
        {
            get;
            set;
        }
    }
}
