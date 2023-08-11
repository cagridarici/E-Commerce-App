using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Entities
{
    /// <summary>
    /// Represent to Product Entity Model.
    /// </summary>
    [Table("Products")]
    public class Product : EntityBase
    {
        [Column("p_name")]
        public string ProductName
        {
            get;
            set;
        }

        [Column("p_unitprice")]
        public decimal UnitPrice
        {
            get;
            set;
        }

        [Column("p_categoryid")]
        public int CategoryId
        {
            get;
            set;
        }

        [Column("p_currencyid")]
        public short CurrencyId
        {
            get;
            set;
        }

        public Currency Currency
        {
            get
            {
                return (Currency)CurrencyId;
            }
            set
            {
                CurrencyId = (short)value;
            }
        }

        [NotMapped]
        public string UnitPriceString
        {
            get
            {
                return UnitPrice.ToString() + " " + Currency.ToString();
            }
        }

        [ForeignKey(nameof(CategoryId))]
        public virtual ProductCategory Category
        {
            get;
            set;
        }
    }

    public enum Currency
    {
        TL,
        USD,
        EUR
    }
}
