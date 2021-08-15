using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Backend.Shared.API.Controllers
{
    /// <summary>
    /// CementerioController
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [ApiController, Route("api/v1/[controller]")]
    public class CementerioController : ControllerBase
    {
        #region Attributes                
        /// <summary>
        /// The cementerio business
        /// </summary>
        private readonly Entities.Interface.Business.ICementerioBusiness CementerioBusiness;
        #endregion

        #region Constructor                                                                                     
        /// <summary>
        /// Initializes a new instance of the <see cref="CementerioController"/> class.
        /// </summary>
        /// <param name="cementerioBusiness">The cementerio business.</param>
        public CementerioController(Entities.Interface.Business.ICementerioBusiness cementerioBusiness)
        {
            CementerioBusiness = cementerioBusiness;
        }
        #endregion

        #region Methods                
        /// <summary>
        /// Gets all cementerio.
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllCementerio")]
        public async Task<ActionResult> GetAllCementerio()
        {
            var result = await CementerioBusiness.GetAllCementerio();
            return StatusCode(result.Code, result);
        }
        #endregion
    }
}
