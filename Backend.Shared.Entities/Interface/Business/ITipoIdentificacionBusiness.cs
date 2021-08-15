using System.Collections.Generic;
using System.Threading.Tasks;


namespace Backend.Shared.Entities.Interface.Business
{
    /// <summary>
    /// ITipoIdentificacion
    /// </summary>
    public interface ITipoIdentificacionBusiness
    {
        /// <summary>
        /// Gets the tipo identificacion.
        /// </summary>
        /// <returns></returns>
        Task<Entities.Responses.ResponseBase<List<Entities.Models.Tramites.PrTipoidentificacion>>> GetTipoIdentificacion();
    }
}
