using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Shared.Entities.Interface.Business
{
    /// <summary>
    /// IMunicipioBusiness
    /// </summary>
    public interface IMunicipioBusiness
    {
        /// <summary>
        /// Gets the municipio by identifier departamento.
        /// </summary>
        /// <param name="idDepartamento">The identifier departamento.</param>
        /// <returns></returns>
        Task<Entities.Responses.ResponseBase<List<Entities.Models.Commons.Municipio>>> GetMunicipioByIdDepartamento(string idDepartamento);

    }
}


