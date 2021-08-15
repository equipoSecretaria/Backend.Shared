using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Backend.Shared.API.Controllers
{
    /// <summary>
    /// PaisController
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [ApiController, Route("api/v1/[controller]")]
    public class PaisController : ControllerBase
    {
        #region Attributes
        /// <summary>
        /// The pais business
        /// </summary>
        private readonly Entities.Interface.Business.IPaisBusiness PaisBusiness;
        #endregion

        #region Constructor                                                             
        /// <summary>
        /// Initializes a new instance of the <see cref="PaisController"/> class.
        /// </summary>
        /// <param name="paisBusiness">The pais business.</param>
        public PaisController(Entities.Interface.Business.IPaisBusiness paisBusiness)
        {
            PaisBusiness = paisBusiness;
        }
        #endregion

        #region Methods            
        /// <summary>
        /// Gets the pais.
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetPais")]
        public async Task<ActionResult> GetPais()
        {
            var result = await PaisBusiness.GetPais();
            return StatusCode(result.Code, result);
        }
        #endregion
    }
}
