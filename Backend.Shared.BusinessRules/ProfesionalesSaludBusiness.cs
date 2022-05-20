using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Backend.Shared.Entities.Interface.Business;
using Backend.Shared.Entities.Models.Tramites;
using Backend.Shared.Entities.Responses;

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

        public async Task<ResponseBase<dynamic>> UpdateProfesional(ProfesionalSalud profesionalSalud, int id)
        {
            try
            {
                var consulta = ($"SELECT * FROM V_PROFESIONALES_SALUD_1 WHERE NROIDENT = {Convert.ToInt64(id)}");
                Console.WriteLine("Profesional => " + consulta);
                var execute = await OracleContext.ExecuteQuery<dynamic>(consulta);

                string QueryToExec = "UPDATE V_PROFESIONALES_SALUD_1 SET TIPO_I = '" + profesionalSalud.TIPO_I +
                                     "', NROIDENT = '" + profesionalSalud.NROIDENT + "' , SITIO_EXP_IDENT = '" +
                                     profesionalSalud.SITIO_EXP_IDENT + "' , NOMBRES = '" +
                                     profesionalSalud.NOMBRES + "' , FECHA_NACIMIENTO = '" +
                                     profesionalSalud.FECHA_NACIMIENTO + "' WHERE NROIDENT = '" + id + "' ";

                if (execute.Count() == 0 )
                {
                    return new ResponseBase<dynamic>(code: System.Net.HttpStatusCode.NotFound, message: "No se encontró el registro para actualizar");

                }
                else
                {
                    var updates = await OracleContext.ExecuteQuery<dynamic>(QueryToExec);
                    Console.WriteLine("registros modificados -> " + updates);
                    return new ResponseBase<dynamic>(System.Net.HttpStatusCode.OK, "registro modificado");
                }
            }
            catch (System.Exception ex)
            {
                TelemetryException.RegisterException(ex);
                return new ResponseBase<dynamic>(code: System.Net.HttpStatusCode.InternalServerError,
                    message: "registro no modificado");
            }
        }

        #endregion
    }
}