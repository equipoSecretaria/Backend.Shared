using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Backend.Shared.API.Controllers
{
    /// <summary>
    /// InstitucionController
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [ApiController, Route("api/v1/[controller]")]
    public class InstitucionController : ControllerBase
    {
        #region Attributes                        
        /// <summary>
        /// The institucion business
        /// </summary>
        private readonly Entities.Interface.Business.IInstitucionBusiness InstitucionBusiness;
        #endregion

        #region Constructor                                                                                             
        /// <summary>
        /// Initializes a new instance of the <see cref="InstitucionController"/> class.
        /// </summary>
        /// <param name="institucionBusiness">The institucion business.</param>
        public InstitucionController(Entities.Interface.Business.IInstitucionBusiness institucionBusiness)
        {
            InstitucionBusiness = institucionBusiness;
        }
        #endregion

        #region Methods                                        
        /// <summary>
        /// Gets the institucion by razon social.
        /// </summary>
        /// <param name="razonSocial">The razon social.</param>
        /// <returns></returns>
        [HttpGet("GetInstitucionByRazonSocial/{razonSocial}")]
        public async Task<ActionResult> GetInstitucionByRazonSocial(string razonSocial)
        {
            var result = await InstitucionBusiness.GetInstitucionByRazonSocial(razonSocial);
            return StatusCode(result.Code, result);
        }
        #endregion
    }
}
