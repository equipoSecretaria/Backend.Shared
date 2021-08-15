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
        /// Gets all departamento.
        /// </summary>
        /// <returns></returns>
        Task<Entities.Responses.ResponseBase<List<Entities.Models.Tramites.PrDepartamento>>> GetAllDepartamento();
    }
}


