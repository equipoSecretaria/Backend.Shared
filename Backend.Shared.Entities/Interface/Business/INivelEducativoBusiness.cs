using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Shared.Entities.Interface.Business
{
    /// <summary>
    /// INivelEducativo
    /// </summary>
    public interface INivelEducativoBusiness
    {
        /// <summary>
        /// Gets the nivel educativo.
        /// </summary>
        /// <returns></returns>
        Task<Entities.Responses.ResponseBase<List<Entities.Models.Tramites.PrNiveleducativo>>> GetNivelEducativo();

    }
}
