using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Backend.Shared.BusinessRules
{
    public class CertificadoDefuncionBusiness : Entities.Interface.Business.ICertificadoDefuncionBusiness
    {

        #region Attributes
        /// <summary>
        /// The oracle context
        /// </summary>
        private readonly Repositories.Context.OracleContext _oracleContext;

        /// <summary>
        /// The telemetry exception
        /// </summary>
        private readonly Utilities.Telemetry.ITelemetryException _telemetryException;
        #endregion

        #region Constructor
        public CertificadoDefuncionBusiness(Repositories.Context.OracleContext oracleContext,
                                            Utilities.Telemetry.ITelemetryException telemetryException)
        {
            _oracleContext = oracleContext;
            _telemetryException = telemetryException;

        }
        #endregion

        #region Methods
        /// <summary>
        /// ValidateCertificadoDefuncion
        /// </summary>
        /// <param name="numeroCertificadoDefuncion"></param>
        /// <returns></returns>
        public async Task<Entities.Responses.ResponseBase<dynamic>> ValidateCertificadoDefuncion(string numeroCertificadoDefuncion)
        {
            try
            {
                var result = await _oracleContext.ExecuteQuery<dynamic>($"SELECT NUM_CERTIFICADO_DEFUNCION FROM V_MUERTOS_INH_CRE WHERE NUM_CERTIFICADO_DEFUNCION = {Convert.ToDecimal(numeroCertificadoDefuncion)}");
                if (result.Count() == 0)
                {
                    return new Entities.Responses.ResponseBase<dynamic>(code: HttpStatusCode.OK, message: Middle.Messages.NoContent);
                }
                return new Entities.Responses.ResponseBase<dynamic>(code: HttpStatusCode.OK, message: Middle.Messages.GetOk, data: true, count: result.Count());
            }
            catch (Exception ex)
            {
                _telemetryException.RegisterException(ex);
                return new Entities.Responses.ResponseBase<dynamic>(code: HttpStatusCode.InternalServerError, message: Middle.Messages.ServerError);
            }
        }
        #endregion
    }
}
