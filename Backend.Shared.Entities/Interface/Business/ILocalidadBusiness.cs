using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Shared.Entities.Interface.Business
{
    /// <summary>
    /// ILocalidadBusiness
    /// </summary>
    public interface ILocalidadBusiness
    {
        /// <summary>
        /// Gets all localidad.
        /// </summary>
        /// <returns></returns>
        Task<Entities.Responses.ResponseBase<List<Entities.Models.Commons.Localidad>>> GetAllLocalidad();

    }
}


