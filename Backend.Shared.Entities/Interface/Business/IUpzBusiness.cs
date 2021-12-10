using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Shared.Entities.Interface.Business
{
    /// <summary>
    /// IMunicipioBusiness
    /// </summary>
    public interface IUpzBusiness
    {
        /// <summary>
        /// Gets the upz by identifier localidad.
        /// </summary>
        /// <param name="idLocalidad">The identifier localidad.</param>
        /// <returns></returns>
        Task<Entities.Responses.ResponseBase<List<Entities.Models.Commons.Upz>>> GetUpzByIdLocalidad(string idLocalidad);

    }
}


