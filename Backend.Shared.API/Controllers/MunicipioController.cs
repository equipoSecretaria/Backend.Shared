using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Backend.Shared.API.Controllers
{
    /// <summary>
    /// MunicipioController
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [ApiController, Route("api/v1/[controller]")]
    public class MunicipioController : ControllerBase
    {
        #region Attributes        
        /// <summary>
        /// The municipio business
        /// </summary>
        private readonly Entities.Interface.Business.IMunicipioBusiness MunicipioBusiness;
        #endregion

        #region Constructor                                                                             
        /// <summary>
        /// Initializes a new instance of the <see cref="MunicipioController"/> class.
        /// </summary>
        /// <param name="municipioBusiness">The municipio business.</param>
        public MunicipioController(Entities.Interface.Business.IMunicipioBusiness municipioBusiness)
        {
            MunicipioBusiness = municipioBusiness;
        }
        #endregion

        #region Methods        
        /// <summary>
        /// Gets the municipio by identifier departamento.
        /// </summary>
        /// <param name="idDepartamento">The identifier departamento.</param>
        /// <returns></returns>
        [HttpGet("GetMunicipioByIdDepartamento/{idDepartamento}")]
        public async Task<ActionResult> GetMunicipioByIdDepartamento(string idDepartamento)
        {
            var result = await MunicipioBusiness.GetMunicipioByIdDepartamento(idDepartamento);
            return StatusCode(result.Code, result);
        }
        #endregion
    }
}
