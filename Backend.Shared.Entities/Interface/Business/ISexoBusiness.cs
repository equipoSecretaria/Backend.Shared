using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Shared.Entities.Interface.Business
{
    /// <summary>
    /// ISexoBusiness
    /// </summary>
    public interface ISexoBusiness
    {
        /// <summary>
        /// Gets the sexo.
        /// </summary>
        /// <returns></returns>
        Task<Entities.Responses.ResponseBase<List<Entities.Models.Tramites.PrSexo>>> GetSexo();

    }
}
