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
        /// _repoMunicipioMySQL
        /// </summary>
        private readonly Entities.Interface.Repository.IBaseRepositoryCommonsMySQL<Entities.Models.Tramites.PrMunicipio> _repoMunicipioMySQL;

        /// <summary>
        /// _repoMunicipioSQL
        /// </summary>
        private readonly Entities.Interface.Repository.IBaseRepositoryCommonsSQLServer<Entities.Models.Commons.Municipio> _repoMunicipioSQL;

        /// <summary>
        /// _telemetryException
        /// </summary>
        private readonly Utilities.Telemetry.ITelemetryException _telemetryException;
        #endregion

        #region Constructor                
        /// <summary>
        /// MunicipioBusiness
        /// </summary>
        /// <param name="repoMunicipioMySQL"></param>
        /// <param name="repoMunicipioSQL"></param>
        /// <param name="telemetryException"></param>
        public MunicipioBusiness(Entities.Interface.Repository.IBaseRepositoryCommonsMySQL<Entities.Models.Tramites.PrMunicipio> repoMunicipioMySQL,
                                 Entities.Interface.Repository.IBaseRepositoryCommonsSQLServer<Entities.Models.Commons.Municipio> repoMunicipioSQL,
                                 Utilities.Telemetry.ITelemetryException telemetryException)
        {
            _repoMunicipioMySQL = repoMunicipioMySQL;
            _repoMunicipioSQL = repoMunicipioSQL;
            _telemetryException = telemetryException;
        }
        #endregion

        #region Methods        
        /// <summary>
        /// Gets the municipio by identifier departamento.
        /// </summary>
        /// <param name="idDepartamento">The identifier departamento.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Entities.Responses.ResponseBase<List<Entities.Models.Tramites.PrMunicipio>>> GetMunicipioByIdDepartamento(int idDepartamento)
        {
            try
            {
                var result = await _repoMunicipioMySQL.GetAllAsync(predicate: p => p.IdDepartamento.Equals(idDepartamento));

                if (result == null)
                {
                    return new Entities.Responses.ResponseBase<List<Entities.Models.Tramites.PrMunicipio>>(code: HttpStatusCode.OK, message: Middle.Messages.NoContent);
                }
                return new Entities.Responses.ResponseBase<List<Entities.Models.Tramites.PrMunicipio>>(code: HttpStatusCode.OK, message: Middle.Messages.GetOk, data: result.ToList(), count: result.Count());
            }
            catch (Exception ex)
            {
                _telemetryException.RegisterException(ex);
                return new Entities.Responses.ResponseBase<List<Entities.Models.Tramites.PrMunicipio>>(code: HttpStatusCode.InternalServerError, message: Middle.Messages.ServerError);
            }
        }

        /// <summary>
        /// GetAllMunicipioByIdDepartamento
        /// </summary>
        /// <param name="idDepartamento"></param>
        /// <returns></returns>
        public async Task<Entities.Responses.ResponseBase<List<Entities.Models.Commons.Municipio>>> GetAllMunicipioByIdDepartamento(string idDepartamento)
        {
            try
            {
                var result = await _repoMunicipioSQL.GetAllAsync(predicate: p => p.IdDepartamento.Equals(Guid.Parse(idDepartamento)));

                if (result == null)
                {
                    return new Entities.Responses.ResponseBase<List<Entities.Models.Commons.Municipio>>(code: HttpStatusCode.OK, message: Middle.Messages.NoContent);
                }
                return new Entities.Responses.ResponseBase<List<Entities.Models.Commons.Municipio>>(code: HttpStatusCode.OK, message: Middle.Messages.GetOk, data: result.ToList(), count: result.Count());
            }
            catch (Exception ex)
            {
                _telemetryException.RegisterException(ex);
                return new Entities.Responses.ResponseBase<List<Entities.Models.Commons.Municipio>>(code: HttpStatusCode.InternalServerError, message: Middle.Messages.ServerError);
            }
        }
        #endregion
    }
}
