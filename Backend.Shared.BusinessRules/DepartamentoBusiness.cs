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
        /// The repository departamento
        /// </summary>
        private readonly Entities.Interface.Repository.IBaseRepositoryCommonsMySQL<Entities.Models.Tramites.PrDepartamento> RepositoryDepartamento;

        /// <summary>
        /// The telemetry exception
        /// </summary>
        private readonly Utilities.Telemetry.ITelemetryException TelemetryException;
        #endregion

        #region Constructor        
        /// <summary>
        /// Initializes a new instance of the <see cref="DepartamentoBusiness"/> class.
        /// </summary>
        /// <param name="repositoryDepartamento">The repository departamento.</param>
        /// <param name="repoDepartamento">The repo departamento.</param>
        /// <param name="telemetryException">The telemetry exception.</param>
        public DepartamentoBusiness(Entities.Interface.Repository.IBaseRepositoryCommonsMySQL<Entities.Models.Tramites.PrDepartamento> repositoryDepartamento,
                                    Utilities.Telemetry.ITelemetryException telemetryException)
        {
            RepositoryDepartamento = repositoryDepartamento;
            TelemetryException = telemetryException;
        }
        #endregion

        #region Methods

        /// <summary>
        /// Gets all departamento.
        /// </summary>
        /// <returns></returns>
        public async Task<Entities.Responses.ResponseBase<List<Entities.Models.Tramites.PrDepartamento>>> GetAllDepartamento()
        {
            try
            {
                var result = await RepositoryDepartamento.GetAllAsync();
                return new Entities.Responses.ResponseBase<List<Entities.Models.Tramites.PrDepartamento>>(code: System.Net.HttpStatusCode.OK, message: "Solicitud ok", data: result.ToList(), count: result.Count());
            }
            catch (Exception ex)
            {
                TelemetryException.RegisterException(ex);
                return new Entities.Responses.ResponseBase<List<Entities.Models.Tramites.PrDepartamento>>(System.Net.HttpStatusCode.InternalServerError, "Error en el servidor!");
            }
        }
        #endregion
    }
}
