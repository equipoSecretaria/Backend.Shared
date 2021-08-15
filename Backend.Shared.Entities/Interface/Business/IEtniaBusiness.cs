using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Shared.Entities.Interface.Business
{
    /// <summary>
    /// IEtnia
    /// </summary>
    public interface IEtniaBusiness
    {
        /// <summary>
        /// Gets the etnia.
        /// </summary>
        /// <returns></returns>
        Task<Entities.Responses.ResponseBase<List<Entities.Models.Tramites.PrEtnia>>> GetEtnia();
    }
}
