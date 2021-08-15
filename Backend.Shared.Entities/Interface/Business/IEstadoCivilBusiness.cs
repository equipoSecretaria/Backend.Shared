using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Shared.Entities.Interface.Business
{
    /// <summary>
    /// IEstadoCivilBusiness
    /// </summary>
    public interface IEstadoCivilBusiness
    {

        /// <summary>
        /// Gets the estadocivil.
        /// </summary>
        /// <returns></returns>
        Task<Entities.Responses.ResponseBase<List<Entities.Models.Tramites.PrEstadocivil>>> GetEstadoCivil();
    }
}
