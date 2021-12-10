using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Backend.Shared.API.Controllers
{
    /// <summary>
    /// MunicipioController
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [ApiController, Route("api/v1/[controller]")]
    public class LocalidadController : ControllerBase
    {
        #region Attributes                
        /// <summary>
        /// The localidad business
        /// </summary>
        private readonly Entities.Interface.Business.ILocalidadBusiness LocalidadBusiness;
        #endregion

        #region Constructor                                                                                     
        /// <summary>
        /// Initializes a new instance of the <see cref="LocalidadController"/> class.
        /// </summary>
        /// <param name="localidadBusiness">The localidad business.</param>
        public LocalidadController(Entities.Interface.Business.ILocalidadBusiness localidadBusiness)
        {
            LocalidadBusiness = localidadBusiness;
        }
        #endregion

        #region Methods                
        /// <summary>
        /// Gets all localidad.
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllLocalidad")]
        public async Task<ActionResult> GetAllLocalidad()
        {
            var result = await LocalidadBusiness.GetAllLocalidad();
            return StatusCode(result.Code, result);
        }
        #endregion
    }
}
