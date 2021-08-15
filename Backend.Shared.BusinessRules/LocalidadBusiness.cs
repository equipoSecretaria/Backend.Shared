using Backend.Shared.Entities.Models.Commons;
using Backend.Shared.Entities.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Backend.Shared.BusinessRules
{
    public class LocalidadBusiness : Entities.Interface.Business.ILocalidadBusiness
    {
        #region Attributes        
        /// <summary>
        /// The repo localidad
        /// </summary>
        private readonly Entities.Interface.Repository.IBaseRepositoryCommonsSQLServer<Entities.Models.Commons.Localidad> RepoLocalidad;

        /// <summary>
        /// The telemetry exception
        /// </summary>
        private readonly Utilities.Telemetry.ITelemetryException TelemetryException;
        #endregion

        #region Constructor                        
        /// <summary>
        /// Initializes a new instance of the <see cref="LocalidadBusiness"/> class.
        /// </summary>
        /// <param name="repoLocalidad">The repo localidad.</param>
        /// <param name="telemetryException">The telemetry exception.</param>
        public LocalidadBusiness(Entities.Interface.Repository.IBaseRepositoryCommonsSQLServer<Entities.Models.Commons.Localidad> repoLocalidad,
                                 Utilities.Telemetry.ITelemetryException telemetryException)
        {
            RepoLocalidad = repoLocalidad;
            TelemetryException = telemetryException;
        }

        #endregion

        #region Methods                
        /// <summary>
        /// Gets all localidad.
        /// </summary>
        /// <returns></returns>
        public async Task<ResponseBase<List<Localidad>>> GetAllLocalidad()
        {
            try
            {
                var result = await RepoLocalidad.GetAllAsync();

                if (result == null)
                {
                    return new Entities.Responses.ResponseBase<List<Localidad>>(code: HttpStatusCode.OK, message: Middle.Messages.NoContent);
                }
                return new Entities.Responses.ResponseBase<List<Localidad>>(code: HttpStatusCode.OK, message: Middle.Messages.GetOk, data: result.ToList(), count: result.Count());
            }
            catch (Exception ex)
            {
                TelemetryException.RegisterException(ex);
                return new Entities.Responses.ResponseBase<List<Localidad>>(code: HttpStatusCode.InternalServerError, message: Middle.Messages.ServerError);
            }
        }
        #endregion
    }
}
