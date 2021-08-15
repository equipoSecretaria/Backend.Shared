using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Shared.BusinessRules
{
    public class TipoIdentificacionBusiness : Entities.Interface.Business.ITipoIdentificacionBusiness
    {
        /// <summary>
        /// The repository tipo identificacion
        /// </summary>
        private readonly Entities.Interface.Repository.IBaseRepositoryCommonsMySQL<Entities.Models.Tramites.PrTipoidentificacion> RepositoryTipoIdentificacion;
        /// <summary>
        /// Initializes a new instance of the <see cref="TipoIdentificacionBusiness"/> class.
        /// </summary>
        /// <param name="repositoryTipoIdentificacion">The repository tipo identificacion.</param>
        public TipoIdentificacionBusiness(Entities.Interface.Repository.IBaseRepositoryCommonsMySQL<Entities.Models.Tramites.PrTipoidentificacion> repositoryTipoIdentificacion)
        {
            RepositoryTipoIdentificacion = repositoryTipoIdentificacion;
        }
        /// <summary>
        /// Gets the tipo identificacion.
        /// </summary>
        /// <returns></returns>
        public async Task<Entities.Responses.ResponseBase<List<Entities.Models.Tramites.PrTipoidentificacion>>> GetTipoIdentificacion()
        {
            try
            {
                var tipoidentificacion = await RepositoryTipoIdentificacion.GetAllAsync();

                return new Entities.Responses.ResponseBase<List<Entities.Models.Tramites.PrTipoidentificacion>>(code: System.Net.HttpStatusCode.OK, message: "Solicitud ok", data: tipoidentificacion.ToList(), count: tipoidentificacion.Count());
            }
            catch (Exception)
            {

                return new Entities.Responses.ResponseBase<List<Entities.Models.Tramites.PrTipoidentificacion>>(System.Net.HttpStatusCode.InternalServerError, "Error en el servidor!");
            }
        }
    }
}
