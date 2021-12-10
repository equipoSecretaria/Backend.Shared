using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Shared.BusinessRules
{
    public class PaisBusiness : Entities.Interface.Business.IPaisBusiness
    {
        /// <summary>
        /// The repository pais
        /// </summary>
        private readonly Entities.Interface.Repository.IBaseRepositoryCommonsMySQL<Entities.Models.Tramites.PrPais> RepositoryPais;
        /// <summary>
        /// Initializes a new instance of the <see cref="PaisBusiness"/> class.
        /// </summary>
        /// <param name="repositoryPais">The repository pais.</param>
        public PaisBusiness(Entities.Interface.Repository.IBaseRepositoryCommonsMySQL<Entities.Models.Tramites.PrPais> repositoryPais)
        {
            RepositoryPais = repositoryPais;
        }
        /// <summary>
        /// Gets the pais.
        /// </summary>
        /// <returns></returns>
        public async Task<Entities.Responses.ResponseBase<List<Entities.Models.Tramites.PrPais>>> GetPais()
        {
            try
            {
                var pais = await RepositoryPais.GetAllAsync();
                return new Entities.Responses.ResponseBase<List<Entities.Models.Tramites.PrPais>>(code: System.Net.HttpStatusCode.OK, message: "Solicitud ok", data: pais.ToList(), count: pais.Count());
            }
            catch (Exception)
            {
                return new Entities.Responses.ResponseBase<List<Entities.Models.Tramites.PrPais>>(System.Net.HttpStatusCode.InternalServerError, "Error en el servidor!");
            }
        }
    }
}
