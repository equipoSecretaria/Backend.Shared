using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Backend.Shared.BusinessRules
{
    public class ProfesionalesSaludBusiness : Entities.Interface.Business.IProfesionalesSaludBusiness
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
        /// Initializes a new instance of the <see cref="ProfesionalesSaludBusiness"/> class.
        /// </summary>
        /// <param name="oracleContext">The oracle context.</param>
        /// <param name="telemetryException">The telemetry exception.</param>
        public ProfesionalesSaludBusiness(Repositories.Context.OracleContext oracleContext, Utilities.Telemetry.ITelemetryException telemetryException)
        {
            OracleContext = oracleContext;
            TelemetryException = telemetryException;
        }
        #endregion

        #region Methods                
        /// <summary>
        /// Gets the profesional salud by numero identificacion.
        /// </summary>
        /// <param name="numeroIdentificacion">The numero identificacion.</param>
        /// <returns></returns>
        public async Task<Entities.Responses.ResponseBase<dynamic>> GetProfesionalSaludByNumeroIdentificacion(string numeroIdentificacion)
        {
            try
            {
                var result = await OracleContext.ExecuteQuery<dynamic>($"SELECT TIPO_I, NROIDENT, SITIO_EXP_IDENT, NOMBRES, APELLIDOS FROM V_PROFESIONALES_SALUD_1 WHERE NROIDENT = {Convert.ToDecimal(numeroIdentificacion)}");
                if (result.Count() == 0)
                {
                    return new Entities.Responses.ResponseBase<dynamic>(code: HttpStatusCode.OK, message: Middle.Messages.NoContent);
                }
                return new Entities.Responses.ResponseBase<dynamic>(code: HttpStatusCode.OK, message: Middle.Messages.GetOk, data: result.ToList(), count: result.Count());
            }
            catch (Exception ex)
            {
                TelemetryException.RegisterException(ex);
                return new Entities.Responses.ResponseBase<dynamic>(code: HttpStatusCode.InternalServerError, message: Middle.Messages.ServerError);
            }
        }
        #endregion
    }
}