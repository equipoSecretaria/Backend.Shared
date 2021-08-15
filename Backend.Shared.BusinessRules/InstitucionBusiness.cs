using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Backend.Shared.BusinessRules
{
    public class InstitucionBusiness : Entities.Interface.Business.IInstitucionBusiness
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
        /// Initializes a new instance of the <see cref="InstitucionBusiness"/> class.
        /// </summary>
        /// <param name="oracleContext">The oracle context.</param>
        /// <param name="telemetryException">The telemetry exception.</param>
        public InstitucionBusiness(Repositories.Context.OracleContext oracleContext, Utilities.Telemetry.ITelemetryException telemetryException)
        {
            OracleContext = oracleContext;
            TelemetryException = telemetryException;
        }
        #endregion

        #region Methods                        
        /// <summary>
        /// Gets the institucion by razon social.
        /// </summary>
        /// <param name="razonSocial">The razon social.</param>
        /// <returns></returns>
        public async Task<Entities.Responses.ResponseBase<List<dynamic>>> GetInstitucionByRazonSocial(string razonSocial)
        {
            try
            {
                var result = await OracleContext.ExecuteQuery<dynamic>($"SELECT * FROM V_INSTITUCIONES WHERE RAZON_S LIKE '%{razonSocial}%'");
                if (result.Count() == 0)
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