using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Shared.Entities.Interface.Business
{
    /// <summary>
    /// IDepartamentoBusiness
    /// </summary>
    public interface IDepartamentoBusiness
    {
        /// <summary>
        /// GetDepartamento
        /// </summary>
        /// <returns></returns>
        Task<Responses.ResponseBase<List<Models.Tramites.PrDepartamento>>> GetDepartamento();

        /// <summary>
        /// GetAllDepartamento
        /// </summary>
        /// <returns></returns>
        Task<Responses.ResponseBase<List<Models.Commons.Departamento>>> GetAllDepartamento();
    }
}


