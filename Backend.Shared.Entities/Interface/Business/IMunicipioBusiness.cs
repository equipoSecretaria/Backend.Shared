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
        /// GetMunicipioByIdDepartamento
        /// </summary>
        /// <param name="idDepartamento"></param>
        /// <returns></returns>
        Task<Responses.ResponseBase<List<Models.Tramites.PrMunicipio>>> GetMunicipioByIdDepartamento(int idDepartamento);

        /// <summary>
        /// GetAllMunicipioByIdDepartamento
        /// </summary>
        /// <param name="idDepartamento"></param>
        /// <returns></returns>
        Task<Responses.ResponseBase<List<Models.Commons.Municipio>>> GetAllMunicipioByIdDepartamento(string idDepartamento);

    }
}


