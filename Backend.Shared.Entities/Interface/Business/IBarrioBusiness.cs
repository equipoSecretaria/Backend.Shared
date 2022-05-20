using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Shared.Entities.Interface.Business
{
    /// <summary>
    /// IMunicipioBusiness
    /// </summary>
    public interface IBarrioBusiness
    {
        /// <summary>
        /// Gets the barrio by identifier upz.
        /// </summary>
        /// <param name="idUpz">The identifier upz.</param>
        /// <returns></returns>
        Task<Entities.Responses.ResponseBase<List<Entities.Models.Commons.Barrio>>> GetBarrioByIdUpz(string idUpz);
        
        
        
        /// <summary>
        /// Gets  barrios .
        /// </summary>
        /// <returns></returns>
        Task<Entities.Responses.ResponseBase<List<Entities.Models.Commons.Barrio>>> GetBarrios();

    }
}


