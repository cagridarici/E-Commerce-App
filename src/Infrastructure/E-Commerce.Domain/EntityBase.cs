using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce.Domain
{
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
    /// int disinda farkli veri tipinde Id tanimi yapilacaksa base alinabilir
    /// </summary>
    /// <typeparam name="T"></typeparam>
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