using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Backend.Shared.Entities.Interface.Business;
using Backend.Shared.Entities.Models.Tramites;
using Backend.Shared.Entities.Responses;
using Backend.Shared.Repositories.Context;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Backend.Shared.BusinessRules
{
    public class CementerioBusiness : Entities.Interface.Business.ICementerioBusiness
    {
        #region Attributes

        /// <summary>
        /// Cache
        /// </summary>
        private readonly IDistributedCache _cache;

        /// <summary>
        /// The oracle context
        /// </summary>
        private readonly Repositories.Context.OracleContext OracleContext;

        /// <summary>
        /// The telemetry exception
        /// </summary>
        private readonly Utilities.Telemetry.ITelemetryException TelemetryException;


        private readonly Entities.Interface.Repository.IBaseRepository<Entities.Models.Tramites.Cementerio>
            _repositoryCementerio;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="CementerioBusiness"/> class.
        /// </summary>
        /// <param name="oracleContext"></param>
        /// <param name="telemetryException"></param>
        /// <param name="cache"></param>
        public CementerioBusiness(Repositories.Context.OracleContext oracleContext,
            Utilities.Telemetry.ITelemetryException telemetryException,
            IDistributedCache cache)
        {
            OracleContext = oracleContext;
            TelemetryException = telemetryException;
            _cache = cache;
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
                //var result = await OracleContext.ExecuteQuery<dynamic>("SELECT * FROM V_CEMENTERIOS");

                //if (result == null)
                //{
                //    return new Entities.Responses.ResponseBase<List<dynamic>>(code: HttpStatusCode.OK, message: Middle.Messages.NoContent);
                //}

                var cacheKey = "getAllCementerio";
                string serializedResultList;
                var resultList = new List<dynamic>();


                var redisResult = await _cache.GetAsync(cacheKey);
                if (redisResult != null)
                {
                    serializedResultList = Encoding.UTF8.GetString(redisResult);
                    resultList = JsonConvert.DeserializeObject<List<dynamic>>(serializedResultList);
                }
                else
                {
                    resultList = await OracleContext.ExecuteQuery<dynamic>("SELECT * FROM V_CEMENTERIOS");

                    serializedResultList = JsonConvert.SerializeObject(resultList.ToList());

                    redisResult = Encoding.UTF8.GetBytes(serializedResultList);

                    var options = new DistributedCacheEntryOptions()
                        .SetAbsoluteExpiration(DateTime.Now.AddDays(1));
                    //    .SetSlidingExpiration(TimeSpan.FromMinutes(2));
                    await _cache.SetAsync(cacheKey, redisResult, options);
                }


                return new Entities.Responses.ResponseBase<List<dynamic>>(code: HttpStatusCode.OK,
                    message: Middle.Messages.GetOk, data: resultList, count: resultList.Count());
            }
            catch (Exception ex)
            {
                TelemetryException.RegisterException(ex);
                return new Entities.Responses.ResponseBase<List<dynamic>>(code: HttpStatusCode.InternalServerError,
                    message: Middle.Messages.ServerError);
            }
        }

        public async Task<ResponseBase<dynamic>> GetCementerioById(string id)
        {
            try
            {
                // var result = await OracleContext.ExecuteQuery<dynamic>($"SELECT * FROM V_CEMENTERIOS WHERE NROIDENT LIKE '%{id}%'");
                var result =
                    await OracleContext.ExecuteQuery<dynamic>(
                        $"SELECT * FROM V_CEMENTERIOS WHERE NROIDENT = {Convert.ToInt32(id)}");
                if (result.Count() == 0)
                {
                    return new Entities.Responses.ResponseBase<dynamic>(code: HttpStatusCode.OK,
                        message: Middle.Messages.NoContent);
                }

                return new Entities.Responses.ResponseBase<dynamic>(code: HttpStatusCode.OK,
                    message: Middle.Messages.GetOk, data: result, count: result.Count());
            }
            catch (Exception ex)
            {
                TelemetryException.RegisterException(ex);
                return new Entities.Responses.ResponseBase<dynamic>(code: HttpStatusCode.InternalServerError,
                    message: Middle.Messages.ServerError);
            }
        }

        public async Task<ResponseBase<dynamic>> UpadteCementerio(Cementerio cementerio, int id)
        {
            try
            {
                
               var consulta = ($"SELECT * FROM V_CEMENTERIOS WHERE NROIDENT = {Convert.ToInt64(id)}");
               Console.WriteLine("consulta =  " + consulta);
               var execute = await OracleContext.ExecuteQuery<dynamic>(consulta);
               
               
               string QueryToExec = "UPDATE V_CEMENTERIOS SET   RAZON_S = '" + cementerio.RAZON_S + "' , DIRECCION = '" + cementerio.DIRECCION +"' , TELEFONO_1 =  '" + cementerio.TELEFONO_1 + "' , TIPO_I_REP =  '" + cementerio.TIPO_I_REP + "' , NROIDENT_REP = '" + 
                                    cementerio.NROIDENT_REP + "' ,NOMBRE_REP = '" + cementerio.NOMBRE_REP + "'  WHERE NROIDENT = '" + id + "' ";
                 

                
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
    }

    #endregion
}
