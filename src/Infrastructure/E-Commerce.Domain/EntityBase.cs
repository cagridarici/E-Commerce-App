using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce.Domain
{
    /// <summary>
    /// Represent to provide a base for entities
    /// </summary>
    [Serializable]
    public abstract class EntityBase : IEntity
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; set; }

        public override string ToString()
        {
            return $"Entity Name: {GetType().Name} , Id: {Id}";
        }
    }

    /// <summary>
    /// Can be used in cases where the id type must be different
    /// </summary>
    /// <typeparam name="T"> Generic Id Type (Guid,Long vs.) </typeparam>
    [Serializable]
    public abstract class EntityBase<T> : IEntity<T>
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual T Id { get; set; }

        public override string ToString()
        {
            return $"Entity Name: {GetType().Name} , Id: {Id}";
        }
    }
}