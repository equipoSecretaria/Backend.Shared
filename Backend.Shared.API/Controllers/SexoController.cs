using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Backend.Shared.API.Controllers
{
    /// <summary>
    /// SexoController
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [ApiController, Route("api/v1/[controller]")]
    public class SexoController : ControllerBase
    {
        #region Attributes
        /// <summary>
        /// The sexo business
        /// </summary>
        private readonly Entities.Interface.Business.ISexoBusiness SexoBusiness;
        #endregion

        #region Constructor             
        /// <summary>
        /// Initializes a new instance of the <see cref="SexoController"/> class.
        /// </summary>
        /// <param name="sexoBusiness">The sexo business.</param>
        public SexoController(Entities.Interface.Business.ISexoBusiness sexoBusiness)
        {
            SexoBusiness = sexoBusiness;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Gets the sexo.
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetSexo")]
        public async Task<ActionResult> GetSexo()
        {
            var result = await SexoBusiness.GetSexo();
            return StatusCode(result.Code, result);
        }
        #endregion

    }
}
