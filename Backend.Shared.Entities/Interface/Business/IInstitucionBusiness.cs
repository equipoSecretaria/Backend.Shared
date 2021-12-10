using Backend.Shared.Entities.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Shared.Entities.Interface.Business
{
    /// <summary>
    /// IInstitucionBusiness
    /// </summary>
    public interface IInstitucionBusiness
    {
        /// <summary>
        /// Gets the institucion by razon social.
        /// </summary>
        /// <param name="razonSocial">The razon social.</param>
        /// <returns></returns>
        Task<ResponseBase<List<dynamic>>> GetInstitucionByRazonSocial(string razonSocial);
    }
}


