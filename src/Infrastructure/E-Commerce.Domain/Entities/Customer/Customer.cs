using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce.Domain.Entities
{
    [Table("Customers")]
    public class Customer : EntityBase
    {
        [Column("c_firstname")]
        public string FirstName
        {
            get;
            set;
        }

        [Column("c_lastname")]
        public string LastName
        {
            get;
            set;
        }

        [Column("c_status")]
        public short Status
        {
            get;
            set;
        }

        [Column("c_email")]
        public string EmailAddress
        {
            get;
            set;
        }

        public virtual ICollection<CustomerAddress> Addresses
        {
            get;
            set;
        }

        [NotMapped]
        public Status StatusValue
        {
            get
            {
                return (Status)Status;
            }
            set
            {
                Status = (short)value;
            }
        }

        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";
    }

    public enum Status
    {
        Active = 1,
        Passive = 0
    }
}
