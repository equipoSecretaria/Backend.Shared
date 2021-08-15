using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Shared.BusinessRules
{
    public class NivelEducativoBusiness : Entities.Interface.Business.INivelEducativoBusiness
    {
        /// <summary>
        /// The repository nivel educativo
        /// </summary>
        private readonly Entities.Interface.Repository.IBaseRepositoryCommonsMySQL<Entities.Models.Tramites.PrNiveleducativo> RepositoryNivelEducativo;
        /// <summary>
        /// Initializes a new instance of the <see cref="NivelEducativoBusiness"/> class.
        /// </summary>
        /// <param name="repositoryNivelEducativo">The repository nivel educativo.</param>
        public NivelEducativoBusiness(Entities.Interface.Repository.IBaseRepositoryCommonsMySQL<Entities.Models.Tramites.PrNiveleducativo> repositoryNivelEducativo)
        {
            RepositoryNivelEducativo = repositoryNivelEducativo;
        }

        /// <summary>
        /// Gets the nivel educativo.
        /// </summary>
        /// <returns></returns>
        public async Task<Entities.Responses.ResponseBase<List<Entities.Models.Tramites.PrNiveleducativo>>> GetNivelEducativo()
        {
            try
            {
                var niveleducativo = await RepositoryNivelEducativo.GetAllAsync();
                return new Entities.Responses.ResponseBase<List<Entities.Models.Tramites.PrNiveleducativo>>(code: System.Net.HttpStatusCode.OK, message: "Solicitud ok", data: niveleducativo.ToList(), count: niveleducativo.Count());
            }
            catch (Exception)
            {

                return new Entities.Responses.ResponseBase<List<Entities.Models.Tramites.PrNiveleducativo>>(code: System.Net.HttpStatusCode.InternalServerError, "Error en el servidor!");
            }
        }
    }
}
