using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Backend.Shared.API.Controllers
{
    /// <summary>
    /// ProfesionalesSaludController
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [ApiController, Route("api/v1/[controller]")]
    public class DominioController : ControllerBase
    {
        #region Attributes                        
        /// <summary>
        /// The dominio business
        /// </summary>
        private readonly Entities.Interface.Business.IDominioBusiness DominioBusiness;
        #endregion

        #region Constructor                                                                                            
        /// <summary>
        /// Initializes a new instance of the <see cref="DominioController"/> class.
        /// </summary>
        /// <param name="dominioBusiness">The dominio business.</param>
        public DominioController(Entities.Interface.Business.IDominioBusiness dominioBusiness)
        {
            DominioBusiness = dominioBusiness;
        }
        #endregion

        #region Methods                                
        /// <summary>
        /// Gets all dominio.
        /// </summary>
        /// <param name="tipoDominio">The tipo dominio.</param>
        /// <returns></returns>
        [HttpGet("GetAllDominio/{tipoDominio}")]
        public async Task<ActionResult> GetAllDominio(string tipoDominio)
        {
            var result = await DominioBusiness.GetAllDominio(tipoDominio);
            return StatusCode(result.Code, result);
        }
        #endregion
    }
}
