using Backend.Shared.Entities.Responses;
using System.Threading.Tasks;

namespace Backend.Shared.Entities.Interface.Business
{
    /// <summary>
    /// IProfesionalesSaludBusiness
    /// </summary>
    public interface IProfesionalesSaludBusiness
    {
        /// <summary>
        /// Gets the profesional salud by numero identificacion.
        /// </summary>
        /// <param name="numeroIdentificacion">The numero identificacion.</param>
        /// <returns></returns>
        Task<ResponseBase<dynamic>> GetProfesionalSaludByNumeroIdentificacion(string numeroIdentificacion);
    }
}


