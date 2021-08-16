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
        Task<Entities.Responses.ResponseBase<List<Entities.Models.Tramites.PrMunicipio>>> GetMunicipioByIdDepartamento(int idDepartamento);

    }
}


