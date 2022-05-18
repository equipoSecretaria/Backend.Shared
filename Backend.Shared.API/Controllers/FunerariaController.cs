using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Backend.Shared.Entities.Models.Tramites;

namespace Backend.Shared.API.Controllers
{
    /// <summary>
    /// FunerariaController
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [ApiController, Route("api/v1/[controller]")]
    public class FunerariaController : ControllerBase
    {
        #region Attributes        
        /// <summary>
        /// The funeraria business
        /// </summary>
        private readonly Entities.Interface.Business.IFunerariaBusiness FunerariaBusiness;
        #endregion

        #region Constructor                                                                             
        /// <summary>
        /// Initializes a new instance of the <see cref="FunerariaController"/> class.
        /// </summary>
        /// <param name="funerariaBusiness">The funeraria business.</param>
        public FunerariaController(Entities.Interface.Business.IFunerariaBusiness funerariaBusiness)
        {
            FunerariaBusiness = funerariaBusiness;
        }
        #endregion

        #region Methods        
        /// <summary>
        /// Gets all funeraria.
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllFuneraria")]
        public async Task<ActionResult> GetAllFuneraria()
        {
            var result = await FunerariaBusiness.GetAllFuneraria();
            return StatusCode(result.Code, result);
        }
        #endregion
        
        
        
        #region Methods        
        /// <summary>
        /// UpdateFuneraria.
        /// </summary>
        /// <returns></returns>
        [HttpPut("UpdateFuneraria")]
        public async Task<ActionResult> UpdateFuneraria(Funeraria funeraria, int id)
        {
            var result = await FunerariaBusiness.UpdateFuneraria(funeraria, id);
            return StatusCode(result.Code, result);
        }
        #endregion
    }
}
