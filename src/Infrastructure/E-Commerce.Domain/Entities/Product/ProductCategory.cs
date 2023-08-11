using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Entities
{
    [Table("ProductCategories")]
    public class ProductCategory : EntityBase
    {
        [Column("pc_name")]
        public string Name
        {
            get;
            set;
        }

        [Column("pc_description")]
        public string Description
        {
            get;
            set;
        }

        public ICollection<Product> Products
        {
            get;
            set;
        }
    }
}
