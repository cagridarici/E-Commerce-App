using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Entities
{
    /// <summary>
    /// Represent to Orders Entity Model.
    /// </summary>
    [Table("Orders")]
    public class Order : EntityBase
    {
        public Order()
        {
            CreateDateUtc = DateTime.UtcNow;
        }

        [Column("o_customerid")]
        public int CustomerId
        {
            get;
            set;
        }

        [Column("o_productid")]
        public int ProductId
        {
            get;
            set;
        }

        [Column("o_amount")]
        public int Amount
        {
            get;
            set;
        }
         

        [Column("o_createddate")]
        public DateTime CreateDateUtc
        {
            get;
            set;
        }

        [Column("o_status")]
        public short OrderStatus
        {
            get;
            set;
        }

        [NotMapped]
        public OrderStatus Status
        {
            get
            {
                return (OrderStatus)OrderStatus;
            }
            set
            {
                OrderStatus = (short)value;
            }
        }

        [ForeignKey(nameof(CustomerId))]
        public virtual Customer Customer
        {
            get;
            set;
        }

        [ForeignKey(nameof(ProductId))]
        public virtual Product Product
        {
            get;
            set;
        }
    }

    public enum OrderStatus
    {
        Pending,
        Failed,
        Expired,
        Shipped,
        Completed,
        Canceled,
        Refunded
    }
}
