using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Backend.Shared.API.Controllers
{
    /// <summary>
    /// EtniaController
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [ApiController, Route("api/v1/[controller]")]
    public class EtniaController : ControllerBase
    {
        #region Attributes
        /// <summary>
        /// The etnia business
        /// </summary>
        private readonly Entities.Interface.Business.IEtniaBusiness EtniaBusiness;
        #endregion

        #region Constructor        
        /// <summary>
        /// Initializes a new instance of the <see cref="EtniaController"/> class.
        /// </summary>
        /// <param name="etniaBusiness">The etnia business.</param>
        public EtniaController(Entities.Interface.Business.IEtniaBusiness etniaBusiness)
        {
            EtniaBusiness = etniaBusiness;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Gets the etnia.
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetEtnia")]
        public async Task<ActionResult> GetEtnia()
        {
            var result = await EtniaBusiness.GetEtnia();
            return StatusCode(result.Code, result);
        }
        #endregion
    }
}
