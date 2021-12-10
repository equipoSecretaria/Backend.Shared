using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Backend.Shared.API.Controllers
{
    /// <summary>
    /// UpzController
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [ApiController, Route("api/v1/[controller]")]
    public class UpzController : ControllerBase
    {
        #region Attributes                
        /// <summary>
        /// The upz business
        /// </summary>
        private readonly Entities.Interface.Business.IUpzBusiness UpzBusiness;
        #endregion

        #region Constructor                                                                                             
        /// <summary>
        /// Initializes a new instance of the <see cref="UpzController"/> class.
        /// </summary>
        /// <param name="upzBusiness">The upz business.</param>
        public UpzController(Entities.Interface.Business.IUpzBusiness upzBusiness)
        {
            UpzBusiness = upzBusiness;
        }
        #endregion

        #region Methods                
        /// <summary>
        /// Gets the upz by identifier localidad.
        /// </summary>
        /// <param name="idLocalidad">The identifier localidad.</param>
        /// <returns></returns>
        [HttpGet("GetUpzByIdLocalidad/{idLocalidad}")]
        public async Task<ActionResult> GetUpzByIdLocalidad(string idLocalidad)
        {
            var result = await UpzBusiness.GetUpzByIdLocalidad(idLocalidad);
            return StatusCode(result.Code, result);
        }
        #endregion
    }
}
