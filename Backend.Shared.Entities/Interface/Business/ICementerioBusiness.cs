using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Shared.Entities.Interface.Business
{
    /// <summary>
    /// ICementerioBusiness
    /// </summary>
    public interface ICementerioBusiness
    {
        /// <summary>
        /// Gets all cementerio.
        /// </summary>
        /// <returns></returns>
        Task<Entities.Responses.ResponseBase<List<dynamic>>> GetAllCementerio();
    }
}


