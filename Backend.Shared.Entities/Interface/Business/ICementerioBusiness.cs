using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.Shared.Entities.Models.Tramites;
using Backend.Shared.Entities.Responses;

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



        /// <summary>Prof
        /// Gets  cementerioById.
        /// </summary>
        /// <returns></returns>
        Task<Entities.Responses.ResponseBase<dynamic>> GetCementerioById(string id);

        
        
        Task<ResponseBase<dynamic>> UpadteCementerio(Cementerio cementerio, int id);
    }
    
    

}
    
    
    

    



