using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Shared.Entities.Interface.Business
{
    /// <summary>
    /// IFunerariaBusiness
    /// </summary>
    public interface IFunerariaBusiness
    {
        /// <summary>
        /// Gets all funeraria.
        /// </summary>
        /// <returns></returns>
        Task<Entities.Responses.ResponseBase<List<dynamic>>> GetAllFuneraria();
    }
}


