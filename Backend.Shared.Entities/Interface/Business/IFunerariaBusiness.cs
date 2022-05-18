using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.Shared.Entities.Models.Tramites;

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
        
        
        
        /// <summary>
        /// UpdateFuneraria.
        /// </summary>
        /// <returns></returns>
        Task<Entities.Responses.ResponseBase<dynamic>>UpdateFuneraria(Funeraria funeraria, int id);
    }
}


