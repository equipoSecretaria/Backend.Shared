using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Shared.Entities.Models.Commons;
using Backend.Shared.Entities.Responses;

namespace Backend.Shared.BusinessRules
{
    public class SubRedBusiness : Entities.Interface.Business.ISubRedBusiness
    {
        #region Attributes

        /// <summary>
        /// The repo barrio
        /// </summary>
        private readonly Entities.Interface.Repository.IBaseRepositoryCommonsSQLServer<Entities.Models.Commons.SubRed> RepoSubRed;

        /// <summary>
        /// The telemetry exception
        /// </summary>
        private readonly Utilities.Telemetry.ITelemetryException TelemetryException;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="SubRedBusiness"/> class.
        /// </summary>
        /// <param name="repoSubRed">The repo SubRed.</param>
        /// <param name="telemetryException">The telemetry exception.</param>
        public SubRedBusiness(
            Entities.Interface.Repository.IBaseRepositoryCommonsSQLServer<Entities.Models.Commons.SubRed> repoSubRed,
            Utilities.Telemetry.ITelemetryException telemetryException)
        {
            RepoSubRed = repoSubRed;
            TelemetryException = telemetryException;
        }


        public async Task<ResponseBase<List<SubRed>>> GetSubRed()
        {
            try
            {
                var subRedes = await RepoSubRed.GetAllAsync();
                return new Entities.Responses.ResponseBase<List<SubRed>>(System.Net.HttpStatusCode.OK, "Solicitud OK",
                    subRedes.ToList(), subRedes.Count());
            }
            catch (Exception)
            {
                return new Entities.Responses.ResponseBase<List<SubRed>>(System.Net.HttpStatusCode.InternalServerError,
                    "Error en el servidor!");
            }
        }

        #endregion
    }
}