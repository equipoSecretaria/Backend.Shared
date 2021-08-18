using Backend.Shared.Entities.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Backend.Shared.BusinessRules
{
    public class MunicipioBusiness : Entities.Interface.Business.IMunicipioBusiness
    {
        #region Attributes
        /// <summary>
        /// The repo municipio
        /// </summary>
        private readonly Entities.Interface.Repository.IBaseRepositoryCommonsMySQL<Entities.Models.Tramites.PrMunicipio> RepoMunicipio;

        /// <summary>
        /// The telemetry exception
        /// </summary>
        private readonly Utilities.Telemetry.ITelemetryException TelemetryException;
        #endregion

        #region Constructor                
        /// <summary>
        /// Initializes a new instance of the <see cref="MunicipioBusiness"/> class.
        /// </summary>
        /// <param name="repoMunicipio">The repo municipio.</param>
        /// <param name="telemetryException">The telemetry exception.</param>
        public MunicipioBusiness(Entities.Interface.Repository.IBaseRepositoryCommonsMySQL<Entities.Models.Tramites.PrMunicipio> repoMunicipio,
                                 Utilities.Telemetry.ITelemetryException telemetryException)
        {
            RepoMunicipio = repoMunicipio;
            TelemetryException = telemetryException;
        }

        #endregion

        #region Methods        
        /// <summary>
        /// Gets the municipio by identifier departamento.
        /// </summary>
        /// <param name="idDepartamento">The identifier departamento.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ResponseBase<List<Entities.Models.Tramites.PrMunicipio>>> GetMunicipioByIdDepartamento(int idDepartamento)
        {
            try
            {
                var result = await RepoMunicipio.GetAllAsync(predicate: p => p.IdDepartamento.Equals(idDepartamento));

                if (result == null)
                {
                    return new Entities.Responses.ResponseBase<List<Entities.Models.Tramites.PrMunicipio>>(code: HttpStatusCode.OK, message: Middle.Messages.NoContent);
                }
                return new Entities.Responses.ResponseBase<List<Entities.Models.Tramites.PrMunicipio>>(code: HttpStatusCode.OK, message: Middle.Messages.GetOk, data: result.ToList(), count: result.Count());
            }
            catch (Exception ex)
            {
                TelemetryException.RegisterException(ex);
                return new Entities.Responses.ResponseBase<List<Entities.Models.Tramites.PrMunicipio>>(code: HttpStatusCode.InternalServerError, message: Middle.Messages.ServerError);
            }
        }
        #endregion
    }
}
