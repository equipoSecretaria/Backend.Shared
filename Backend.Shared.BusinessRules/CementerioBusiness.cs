﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Backend.Shared.BusinessRules
{
    public class CementerioBusiness : Entities.Interface.Business.ICementerioBusiness
    {
        #region Attributes
        /// <summary>
        /// The oracle context
        /// </summary>
        private readonly Repositories.Context.OracleContext OracleContext;

        /// <summary>
        /// The telemetry exception
        /// </summary>
        private readonly Utilities.Telemetry.ITelemetryException TelemetryException;
        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="CementerioBusiness"/> class.
        /// </summary>
        /// <param name="oracleContext">The oracle context.</param>
        /// <param name="telemetryException">The telemetry exception.</param>
        public CementerioBusiness(Repositories.Context.OracleContext oracleContext, Utilities.Telemetry.ITelemetryException telemetryException)
        {
            OracleContext = oracleContext;
            TelemetryException = telemetryException;
        }
        #endregion

        #region Methods        
        /// <summary>
        /// Gets all cementerio.
        /// </summary>
        /// <returns></returns>
        public async Task<Entities.Responses.ResponseBase<List<dynamic>>> GetAllCementerio()
        {
            try
            {
                var result = await OracleContext.ExecuteQuery<dynamic>("SELECT * FROM V_CEMENTERIOS");
                if (result == null)
                {
                    return new Entities.Responses.ResponseBase<List<dynamic>>(code: HttpStatusCode.OK, message: Middle.Messages.NoContent);
                }
                return new Entities.Responses.ResponseBase<List<dynamic>>(code: HttpStatusCode.OK, message: Middle.Messages.GetOk, data: result.ToList(), count: result.Count());
            }
            catch (Exception ex)
            {
                TelemetryException.RegisterException(ex);
                return new Entities.Responses.ResponseBase<List<dynamic>>(code: HttpStatusCode.InternalServerError, message: Middle.Messages.ServerError);
            }
        }
        #endregion
    }
}