using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Entities
{
    [Table("CustomerAddresses")]
    public class CustomerAddress : EntityBase
    {
        [Column("ca_customerid")]
        public int CustomerId
        {
            get;
            set;
        }

        [Column("ca_addressline1")]
        public string AddressLine1
        {
            get;
            set;
        }

        [Column("ca_addressline2")]
        public string AddressLine2
        {
            get;
            set;
        }

        [Column("ca_city")]
        public string City
        {
            get;
            set;
        }

        [Column("ca_postalcode")]
        public string PostalCode
        {
            get;
            set;
        }

        [Column("ca_country")]
        public string Country
        {
            get;
            set;
        }

        [ForeignKey(nameof(CustomerId))]
        public virtual Customer Customer
        {
            get;
            set;
        }
    }
}
