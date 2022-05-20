using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Shared.API.Controllers
{
    
    /// <summary>
    /// SubRedController
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [ApiController, Route("api/v1/[controller]")]
    public class SubRedController : ControllerBase
    {
        
        #region Attributes                
        /// <summary>
        /// The barrio business
        /// </summary>
        private readonly Entities.Interface.Business.ISubRedBusiness SubRedBusiness;
        #endregion
        
        #region Constructor                                                                                     
        /// <summary>
        /// Initializes a new instance of the <see cref="SubRedController"/> class.
        /// </summary>
        /// <param name="subRedBusiness">The barrio business.</param>
        public SubRedController(Entities.Interface.Business.ISubRedBusiness subRedBusiness)
        {
            SubRedBusiness = subRedBusiness;
        }
        #endregion
        
        
        #region Methods                
        /// <summary>
        /// Gets SubRed.
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetSubRed")]
        
        public async Task<ActionResult> GetSubRed()
        {
            var result = await SubRedBusiness.GetSubRed();
            return StatusCode(result.Code, result);
        }
        #endregion
    }
}