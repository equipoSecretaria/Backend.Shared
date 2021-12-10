using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Backend.Shared.API.Controllers
{
    /// <summary>
    /// TipoIdentificacionController
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [ApiController, Route("api/v1/[controller]")]
    public class TipoIdentificacionController : ControllerBase
    {
        #region Attributes
        /// <summary>
        /// The tipo identificacion business
        /// </summary>
        private readonly Entities.Interface.Business.ITipoIdentificacionBusiness TipoIdentificacionBusiness;
        #endregion

        #region Constructor                                                                     
        /// <summary>
        /// Initializes a new instance of the <see cref="TipoIdentificacionController"/> class.
        /// </summary>
        /// <param name="tipoIdentificacionBusiness">The tipo identificacion business.</param>
        public TipoIdentificacionController(Entities.Interface.Business.ITipoIdentificacionBusiness tipoIdentificacionBusiness)
        {
            TipoIdentificacionBusiness = tipoIdentificacionBusiness;
        }
        #endregion

        #region Methods                    
        /// <summary>
        /// Gets the tipo identificacion.
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetTipoIdentificacion")]
        public async Task<ActionResult> GetTipoIdentificacion()
        {
            var result = await TipoIdentificacionBusiness.GetTipoIdentificacion();
            return StatusCode(result.Code, result);
        }
        #endregion

    }
}
