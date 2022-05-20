using Backend.Shared.Entities.Models.Commons;
using Backend.Shared.Entities.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Backend.Shared.Entities.Models.Tramites;

namespace Backend.Shared.BusinessRules
{
    public class BarrioBusiness : Entities.Interface.Business.IBarrioBusiness
    {
        #region Attributes                
        /// <summary>
        /// The repo barrio
        /// </summary>
        private readonly Entities.Interface.Repository.IBaseRepositoryCommonsSQLServer<Entities.Models.Commons.Barrio> RepoBarrio;

        /// <summary>
        /// The telemetry exception
        /// </summary>
        private readonly Utilities.Telemetry.ITelemetryException TelemetryException;
        #endregion

        #region Constructor                                        
        /// <summary>
        /// Initializes a new instance of the <see cref="BarrioBusiness"/> class.
        /// </summary>
        /// <param name="repoBarrio">The repo barrio.</param>
        /// <param name="telemetryException">The telemetry exception.</param>
        public BarrioBusiness(Entities.Interface.Repository.IBaseRepositoryCommonsSQLServer<Entities.Models.Commons.Barrio> repoBarrio,
                                 Utilities.Telemetry.ITelemetryException telemetryException)
        {
            RepoBarrio = repoBarrio;
            TelemetryException = telemetryException;
        }

        #endregion

        #region Methods                        
        /// <summary>
        /// Gets the barrio by identifier upz.
        /// </summary>
        /// <param name="idUpz">The identifier upz.</param>
        /// <returns></returns>
        public async Task<ResponseBase<List<Barrio>>> GetBarrioByIdUpz(string idUpz)
        {
            try
            {
                var result = await RepoBarrio.GetAllAsync(predicate: p => p.IdUpz.Equals(Guid.Parse(idUpz)));

                if (result == null)
                {
                    return new Entities.Responses.ResponseBase<List<Barrio>>(code: HttpStatusCode.OK, message: Middle.Messages.NoContent);
                }
                return new Entities.Responses.ResponseBase<List<Barrio>>(code: HttpStatusCode.OK, message: Middle.Messages.GetOk, data: result.ToList(), count: result.Count());
            }
            catch (Exception ex)
            {
                TelemetryException.RegisterException(ex);
                return new Entities.Responses.ResponseBase<List<Barrio>>(code: HttpStatusCode.InternalServerError, message: Middle.Messages.ServerError);
            }
        }

        public async Task<ResponseBase<List<Barrio>>> GetBarrios()
        {
            try
            {
                var barrios = await RepoBarrio.GetAllAsync();
                return new Entities.Responses.ResponseBase<List<Barrio>>(System.Net.HttpStatusCode.OK, "Solicitud OK",
                    barrios.ToList(), barrios.Count());
            }            catch (Exception)
            {
                return new Entities.Responses.ResponseBase<List<Barrio>>(System.Net.HttpStatusCode.InternalServerError, "Error en el servidor!");
            }
        }

        #endregion
    }
}
