using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Backend.Shared.Entities.Models.Tramites;
using Backend.Shared.Entities.Responses;

namespace Backend.Shared.BusinessRules
{
    public class FunerariaBusiness : Entities.Interface.Business.IFunerariaBusiness
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
        /// Initializes a new instance of the <see cref="FunerariaBusiness"/> class.
        /// </summary>
        /// <param name="oracleContext">The oracle context.</param>
        /// <param name="telemetryException">The telemetry exception.</param>
        public FunerariaBusiness(Repositories.Context.OracleContext oracleContext, Utilities.Telemetry.ITelemetryException telemetryException)
        {
            OracleContext = oracleContext;
            TelemetryException = telemetryException;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Gets all funeraria.
        /// </summary>
        /// <returns></returns>
        public async Task<Entities.Responses.ResponseBase<List<dynamic>>> GetAllFuneraria()
        {
            try
            {
                var result = await OracleContext.ExecuteQuery<dynamic>("SELECT * FROM V_FUNERARIAS");
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

        public async Task<ResponseBase<dynamic>> UpdateFuneraria(Funeraria funeraria, int id)
        {
            try
            {
                var consulta = ($"SELECT * FROM V_FUNERARIAS WHERE NROIDENT = {Convert.ToInt64(id)}");
                Console.WriteLine("consulta =  " + consulta);
                var execute = await OracleContext.ExecuteQuery<dynamic>(consulta);
                
                
                string QueryToExec = "UPDATE  SECRETARIA.V_FUNERARIAS SET   TIPO_I = '"+ funeraria.TIPO_I + "' ,  RAZON_S = '" + funeraria.RAZON_S + "' , DIRECCION = '" + funeraria.DIRECCION +"' , TELEFONO_1 = '" + 
                                     funeraria.TELEFONO_1 + "' , TIPO_I_PROP = '" + funeraria.TIPO_I_PROP + "' ,  NROIDENT_PROP = '" + funeraria.NROIDENT_PROP + "' , NOMBRE_PROP = '" + funeraria.NOMBRE_PROP + "' , NUM_SALAS = '" + 
                                     + funeraria.NUM_SALAS +"' , TIPO_I_REP = '" + funeraria.TIPO_I_REP + "' , NROIDENT_REP = '" + funeraria.NROIDENT_REP + "' , NOMBRE_REP = '" + funeraria.NOMBRE_REP + "'  WHERE NROIDENT = '" + id + "'";

                if (execute.Count() == 0)
                {
                    return new ResponseBase<dynamic>(code: System.Net.HttpStatusCode.NotFound, message: "No se encontró el registro para actualizar");
 
                }
                else
                {
                    var updates = await OracleContext.ExecuteQuery<dynamic>(QueryToExec);
                    Console.WriteLine("registros modificados -> " + updates);
                    return new ResponseBase<dynamic>(code: System.Net.HttpStatusCode.OK, message: "registro modificado");
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