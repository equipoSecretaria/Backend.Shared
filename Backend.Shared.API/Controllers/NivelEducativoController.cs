using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Backend.Shared.API.Controllers
{
    /// <summary>
    /// NivelEducativoController
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [ApiController, Route("api/v1/[controller]")]
    public class NivelEducativoController : ControllerBase
    {
        #region Attributes

        /// <summary>
        /// The nivel educativo business
        /// </summary>
        private readonly Entities.Interface.Business.INivelEducativoBusiness NivelEducativoBusiness;
        #endregion

        #region Constructor                                                                                
        /// <summary>
        /// Initializes a new instance of the <see cref="NivelEducativoController"/> class.
        /// </summary>
        /// <param name="nivelEducativoBusiness">The nivel educativo business.</param>
        public NivelEducativoController(Entities.Interface.Business.INivelEducativoBusiness nivelEducativoBusiness)
        {
            NivelEducativoBusiness = nivelEducativoBusiness;
        }
        #endregion

        #region Methods

        /// <summary>
        /// Gets the nivel educativo.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetNivelEducativo")]
        public async Task<ActionResult> GetNivelEducativo()
        {
            var result = await NivelEducativoBusiness.GetNivelEducativo();
            return StatusCode(result.Code, result);
        }
        #endregion

    }
}
