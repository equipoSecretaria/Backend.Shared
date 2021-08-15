using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Shared.BusinessRules
{
    public class EstadoCivilBusiness : Entities.Interface.Business.IEstadoCivilBusiness
    {
        /// <summary>
        /// The repository estadocivil
        /// </summary>
        private readonly Entities.Interface.Repository.IBaseRepositoryCommonsMySQL<Entities.Models.Tramites.PrEstadocivil> RepositoryEstadocivil;
        /// <summary>
        /// Initializes a new instance of the <see cref="EstadoCivilBusiness"/> class.
        /// </summary>
        /// <param name="repositoryEstadocivil">The repository estadocivil.</param>
        public EstadoCivilBusiness(Entities.Interface.Repository.IBaseRepositoryCommonsMySQL<Entities.Models.Tramites.PrEstadocivil> repositoryEstadocivil)
        {
            RepositoryEstadocivil = repositoryEstadocivil;
        }

        /// <summary>
        /// Gets the estadocivil.
        /// </summary>
        /// <returns></returns>
        public async Task<Entities.Responses.ResponseBase<List<Entities.Models.Tramites.PrEstadocivil>>> GetEstadoCivil()
        {
            try
            {
                var estadocivil = await RepositoryEstadocivil.GetAllAsync();
                return new Entities.Responses.ResponseBase<List<Entities.Models.Tramites.PrEstadocivil>>(code: System.Net.HttpStatusCode.OK, message: "Solicitud ok", data: estadocivil.ToList(), count: estadocivil.Count());
            }
            catch (Exception)
            {
                return new Entities.Responses.ResponseBase<List<Entities.Models.Tramites.PrEstadocivil>>(code: System.Net.HttpStatusCode.InternalServerError, "Error en el servidor!");
            }
        }
    }
}
