using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Shared.Entities.Interface.Business
{
    /// <summary>
    /// IPais
    /// </summary>
    public interface IPaisBusiness
    {
        /// <summary>
        /// Gets the pais.
        /// </summary>
        /// <returns></returns>
        Task<Entities.Responses.ResponseBase<List<Entities.Models.Tramites.PrPais>>> GetPais();

    }
}