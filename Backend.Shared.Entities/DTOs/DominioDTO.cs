using System;

namespace Backend.Shared.Entities.DTOs
{
    public class DominioDTO
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; set; }
        /// <summary>
        /// Gets or sets the descripcion.
        /// </summary>
        /// <value>
        /// The descripcion.
        /// </value>
        public string Descripcion { get; set; }

        /// <summary>
        /// Gets or sets the orden.
        /// </summary>
        /// <value>
        /// The orden.
        /// </value>
        public int? Orden { get; set; }
    }
}
