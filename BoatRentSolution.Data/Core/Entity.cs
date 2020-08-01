using System.ComponentModel.DataAnnotations;

namespace BoatRentSolution.Data.Core
{
    /// <summary>
    /// Entity abstarct class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Entity<T> : IEntity<T>
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [Key]
        public virtual T Id { get; set; }
    }
}