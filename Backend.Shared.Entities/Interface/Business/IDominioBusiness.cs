using Backend.Shared.Entities.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Shared.Entities.Interface.Business
{
    /// <summary>
    /// IDominioBusiness
    /// </summary>
    public interface IDominioBusiness
    {
        /// <summary>
        /// Gets all dominio.
        /// </summary>
        /// <param name="tipoDominio">The tipo dominio.</param>
        /// <returns></returns>
        Task<ResponseBase<List<Entities.DTOs.DominioDTO>>> GetAllDominio(string tipoDominio);
    }
}


