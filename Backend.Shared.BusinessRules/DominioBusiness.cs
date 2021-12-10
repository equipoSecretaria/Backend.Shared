using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Backend.Shared.BusinessRules
{
    public class DominioBusiness : Entities.Interface.Business.IDominioBusiness
    {
        #region Attributes                
        /// <summary>
        /// The repository dominio
        /// </summary>
        private readonly Entities.Interface.Repository.IBaseRepositoryCommonsSQLServer<Entities.Models.Commons.Dominio> RepositoryDominio;

        /// <summary>
        /// The telemetry exception
        /// </summary>
        private readonly Utilities.Telemetry.ITelemetryException TelemetryException;
        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="DominioBusiness"/> class.
        /// </summary>
        /// <param name="repositoryDominio">The repository dominio.</param>
        /// <param name="telemetryException">The telemetry exception.</param>
        public DominioBusiness(Entities.Interface.Repository.IBaseRepositoryCommonsSQLServer<Entities.Models.Commons.Dominio> repositoryDominio, Utilities.Telemetry.ITelemetryException telemetryException)
        {
            RepositoryDominio = repositoryDominio;
            TelemetryException = telemetryException;
        }
        #endregion

        #region Methods                        
        /// <summary>
        /// Gets all dominio.
        /// </summary>
        /// <param name="tipoDominio">The tipo dominio.</param>
        /// <returns></returns>
        public async Task<Entities.Responses.ResponseBase<List<Entities.DTOs.DominioDTO>>> GetAllDominio(string tipoDominio)
        {
            try
            {
                var result = await RepositoryDominio.GetAllAsync(predicate: p => p.Estado.Equals(1) && p.TipoDominio.Equals(Guid.Parse(tipoDominio)), selector: s => new Entities.Models.Commons.Dominio { Id = s.Id, Descripcion = s.Descripcion, Orden = s.Orden });

                if (result == null)
                {
                    return new Entities.Responses.ResponseBase<List<Entities.DTOs.DominioDTO>>(code: HttpStatusCode.OK, message: Middle.Messages.NoContent);
                }

                var resultDTO = new List<Entities.DTOs.DominioDTO>();

                foreach (var item in result)
                {
                    resultDTO.Add(new Entities.DTOs.DominioDTO
                    {
                        Id = item.Id,
                        Descripcion = item.Descripcion,
                        Orden = item.Orden
                    });
                }

                return new Entities.Responses.ResponseBase<List<Entities.DTOs.DominioDTO>>(code: HttpStatusCode.OK, message: Middle.Messages.GetOk, data: resultDTO.OrderBy(x => x.Orden).ToList(), count: resultDTO.Count());
            }
            catch (Exception ex)
            {
                TelemetryException.RegisterException(ex);
                return new Entities.Responses.ResponseBase<List<Entities.DTOs.DominioDTO>>(code: HttpStatusCode.InternalServerError, message: Middle.Messages.ServerError);
            }
        }
        #endregion
    }
}