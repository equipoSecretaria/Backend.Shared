using Backend.Shared.Entities.Models.Commons;
using Backend.Shared.Entities.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Backend.Shared.BusinessRules
{
    public class UpzBusiness : Entities.Interface.Business.IUpzBusiness
    {
        #region Attributes        
        /// <summary>
        /// The repo upz
        /// </summary>
        private readonly Entities.Interface.Repository.IBaseRepositoryCommonsSQLServer<Entities.Models.Commons.Upz> RepoUpz;

        /// <summary>
        /// The telemetry exception
        /// </summary>
        private readonly Utilities.Telemetry.ITelemetryException TelemetryException;
        #endregion

        #region Constructor                                
        /// <summary>
        /// Initializes a new instance of the <see cref="UpzBusiness"/> class.
        /// </summary>
        /// <param name="repoUpz">The repo upz.</param>
        /// <param name="telemetryException">The telemetry exception.</param>
        public UpzBusiness(Entities.Interface.Repository.IBaseRepositoryCommonsSQLServer<Entities.Models.Commons.Upz> repoUpz,
                                 Utilities.Telemetry.ITelemetryException telemetryException)
        {
            RepoUpz = repoUpz;
            TelemetryException = telemetryException;
        }

        #endregion

        #region Methods                
        /// <summary>
        /// Gets the upz by identifier localidad.
        /// </summary>
        /// <param name="idLocalidad">The identifier localidad.</param>
        /// <returns></returns>
        public async Task<ResponseBase<List<Upz>>> GetUpzByIdLocalidad(string idLocalidad)
        {
            try
            {
                var result = await RepoUpz.GetAllAsync(predicate: p => p.IdLocalidad.Equals(Guid.Parse(idLocalidad)));

                if (result == null)
                {
                    return new Entities.Responses.ResponseBase<List<Upz>>(code: HttpStatusCode.OK, message: Middle.Messages.NoContent);
                }
                return new Entities.Responses.ResponseBase<List<Upz>>(code: HttpStatusCode.OK, message: Middle.Messages.GetOk, data: result.ToList(), count: result.Count());
            }
            catch (Exception ex)
            {
                TelemetryException.RegisterException(ex);
                return new Entities.Responses.ResponseBase<List<Upz>>(code: HttpStatusCode.InternalServerError, message: Middle.Messages.ServerError);
            }
        }
        #endregion
    }
}
