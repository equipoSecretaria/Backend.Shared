using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
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
                        .SetAbsoluteExpiration(DateTime.Now.AddMinutes(10))
                        .SetSlidingExpiration(TimeSpan.FromMinutes(2));
                    await _cache.SetAsync(cacheKey, redisResult, options);
                }


                return new Entities.Responses.ResponseBase<List<dynamic>>(code: HttpStatusCode.OK, message: Middle.Messages.GetOk, data: resultList, count: resultList.Count());
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