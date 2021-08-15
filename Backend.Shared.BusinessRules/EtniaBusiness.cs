using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Shared.BusinessRules
{
    public class EtniaBusiness : Entities.Interface.Business.IEtniaBusiness
    {
        /// <summary>
        /// The repository etnia
        /// </summary>
        private readonly Entities.Interface.Repository.IBaseRepositoryCommonsMySQL<Entities.Models.Tramites.PrEtnia> RepositoryEtnia;
        /// <summary>
        /// Initializes a new instance of the <see cref="EtniaBusiness"/> class.
        /// </summary>
        /// <param name="repositoryEtnia">The repository etnia.</param>
        public EtniaBusiness(Entities.Interface.Repository.IBaseRepositoryCommonsMySQL<Entities.Models.Tramites.PrEtnia> repositoryEtnia)
        {
            RepositoryEtnia = repositoryEtnia;
        }
        /// <summary>
        /// Gets the etnia.
        /// </summary>
        /// <returns></returns>
        public async Task<Entities.Responses.ResponseBase<List<Entities.Models.Tramites.PrEtnia>>> GetEtnia()
        {
            try
            {
                var etnia = await RepositoryEtnia.GetAllAsync();
                return new Entities.Responses.ResponseBase<List<Entities.Models.Tramites.PrEtnia>>(code: System.Net.HttpStatusCode.OK, message: "Solicitud ok", data: etnia.ToList(), count: etnia.Count());
            }
            catch (Exception)
            {
                return new Entities.Responses.ResponseBase<List<Entities.Models.Tramites.PrEtnia>>(System.Net.HttpStatusCode.InternalServerError, "Error en el servidor!");
            }
        }
    }
}
