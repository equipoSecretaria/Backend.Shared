using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Backend.Shared.API.Controllers
{
    /// <summary>
    /// CertificadoDefuncionController
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [ApiController, Route("api/v1/[controller]")]
    public class CertificadoDefuncionController : ControllerBase
    {
        #region Attributes                
        /// <summary>
        /// _certificadoDefuncionBusiness
        /// </summary>
        private readonly Entities.Interface.Business.ICertificadoDefuncionBusiness _certificadoDefuncionBusiness;
        #endregion

        #region Constructor                                                                                     
        /// <summary>
        /// CertificadoDefuncionController
        /// </summary>
        /// <param name="certificadoDefuncionBusiness"></param>
        public CertificadoDefuncionController(Entities.Interface.Business.ICertificadoDefuncionBusiness certificadoDefuncionBusiness)
        {
            _certificadoDefuncionBusiness = certificadoDefuncionBusiness;
        }
        #endregion

        #region Methods                        
        /// <summary>
        /// ValidateCertificadoDefuncion
        /// </summary>
        /// <param name="numeroCertificadoDefuncion"></param>
        /// <returns></returns>
        [HttpGet("ValidateCertificadoDefuncion/{numeroIdentificacion}")]
        public async Task<ActionResult> ValidateCertificadoDefuncion(string numeroCertificadoDefuncion)
        {
            var result = await _certificadoDefuncionBusiness.ValidateCertificadoDefuncion(numeroCertificadoDefuncion);
            return StatusCode(result.Code, result);
        }
        #endregion
    }
}
