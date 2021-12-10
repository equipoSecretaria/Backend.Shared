using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Shared.BusinessRules
{
    public class DepartamentoBusiness : Entities.Interface.Business.IDepartamentoBusiness
    {
        #region Attributes
        /// <summary>
        /// _repositoryDepartamentoMySQL
        /// </summary>
        private readonly Entities.Interface.Repository.IBaseRepositoryCommonsMySQL<Entities.Models.Tramites.PrDepartamento> _repositoryDepartamentoMySQL;

        /// <summary>
        /// _repositoryDepartamentoSQL
        /// </summary>
        private readonly Entities.Interface.Repository.IBaseRepositoryCommonsSQLServer<Entities.Models.Commons.Departamento> _repositoryDepartamentoSQL;

        /// <summary>
        /// The telemetry exception
        /// </summary>
        private readonly Utilities.Telemetry.ITelemetryException TelemetryException;
        #endregion

        #region Constructor        
        /// <summary>
        /// DepartamentoBusiness
        /// </summary>
        /// <param name="repositoryDepartamentoMySQL"></param>
        /// <param name="repositoryDepartamentoSQL"></param>
        /// <param name="telemetryException"></param>
        public DepartamentoBusiness(Entities.Interface.Repository.IBaseRepositoryCommonsMySQL<Entities.Models.Tramites.PrDepartamento> repositoryDepartamentoMySQL,
                                    Entities.Interface.Repository.IBaseRepositoryCommonsSQLServer<Entities.Models.Commons.Departamento> repositoryDepartamentoSQL,
                                    Utilities.Telemetry.ITelemetryException telemetryException)
        {
            _repositoryDepartamentoMySQL = repositoryDepartamentoMySQL;
            _repositoryDepartamentoSQL = repositoryDepartamentoSQL;
            TelemetryException = telemetryException;
        }
        #endregion

        #region Methods

        /// <summary>
        /// Gets all departamento.
        /// </summary>
        /// <returns></returns>
        public async Task<Entities.Responses.ResponseBase<List<Entities.Models.Tramites.PrDepartamento>>> GetDepartamento()
        {
            try
            {
                var result = await _repositoryDepartamentoMySQL.GetAllAsync();
                return new Entities.Responses.ResponseBase<List<Entities.Models.Tramites.PrDepartamento>>(code: System.Net.HttpStatusCode.OK, message: "Solicitud ok", data: result.ToList(), count: result.Count());
            }
            catch (Exception ex)
            {
                TelemetryException.RegisterException(ex);
                return new Entities.Responses.ResponseBase<List<Entities.Models.Tramites.PrDepartamento>>(System.Net.HttpStatusCode.InternalServerError, "Error en el servidor!");
            }
        }

        /// <summary>
        /// GetAllDepartamento
        /// </summary>
        /// <returns></returns>
        public async Task<Entities.Responses.ResponseBase<List<Entities.Models.Commons.Departamento>>> GetAllDepartamento()
        {
            try
            {
                var result = await _repositoryDepartamentoSQL.GetAllAsync();
                return new Entities.Responses.ResponseBase<List<Entities.Models.Commons.Departamento>>(code: System.Net.HttpStatusCode.OK, message: "Solicitud ok", data: result.ToList(), count: result.Count());
            }
            catch (Exception ex)
            {
                TelemetryException.RegisterException(ex);
                return new Entities.Responses.ResponseBase<List<Entities.Models.Commons.Departamento>>(System.Net.HttpStatusCode.InternalServerError, "Error en el servidor!");
            }
        }
        #endregion
    }
}
