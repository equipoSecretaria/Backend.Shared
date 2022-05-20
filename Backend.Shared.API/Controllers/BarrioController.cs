using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Backend.Shared.API.Controllers
{
    /// <summary>
    /// BarrioController
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [ApiController, Route("api/v1/[controller]")]
    public class BarrioController : ControllerBase
    {
        #region Attributes                
        /// <summary>
        /// The barrio business
        /// </summary>
        private readonly Entities.Interface.Business.IBarrioBusiness BarrioBusiness;
        #endregion

        #region Constructor                                                                                     
        /// <summary>
        /// Initializes a new instance of the <see cref="BarrioController"/> class.
        /// </summary>
        /// <param name="barrioBusiness">The barrio business.</param>
        public BarrioController(Entities.Interface.Business.IBarrioBusiness barrioBusiness)
        {
            BarrioBusiness = barrioBusiness;
        }
        #endregion

        #region Methods                
        /// <summary>
        /// Gets the barrio by identifier upz.
        /// </summary>
        /// <param name="idUpz">The identifier upz.</param>
        /// <returns></returns>
        [HttpGet("GetBarrioByIdUpz/{idUpz}")]
        public async Task<ActionResult> GetBarrioByIdUpz(string idUpz)
        {
            var result = await BarrioBusiness.GetBarrioByIdUpz(idUpz);
            return StatusCode(result.Code, result);
        }
        #endregion
        
        
        #region Methods                
        /// <summary>
        /// Gets the barrio by identifier upz.
        /// </summary>
        /// <param name="idUpz">The identifier upz.</param>
        /// <returns></returns>
        [HttpGet("GetBarrios")]
        public async Task<ActionResult> GetBarrio()
        {
            var result = await BarrioBusiness.GetBarrios();
            return StatusCode(result.Code, result);
        }
        #endregion
    }
}
