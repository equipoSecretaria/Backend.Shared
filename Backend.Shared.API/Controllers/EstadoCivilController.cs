using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Backend.Shared.API.Controllers
{
    /// <summary>
    /// EstadoCivil
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [ApiController, Route("api/v1/[controller]")]
    public class EstadoCivilController : ControllerBase
    {
        #region Attributes
        /// <summary>
        /// The estado civil business
        /// </summary>
        private readonly Entities.Interface.Business.IEstadoCivilBusiness EstadoCivilBusiness;
        #endregion

        #region Constructor                                                                

        /// <summary>
        /// Initializes a new instance of the <see cref="EstadoCivilController"/> class.
        /// </summary>
        /// <param name="estadoCivilBusiness">The estado civil business.</param>
        public EstadoCivilController(Entities.Interface.Business.IEstadoCivilBusiness estadoCivilBusiness)
        {
            EstadoCivilBusiness = estadoCivilBusiness;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Gets the estado civil.
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetEstadoCivil")]
        public async Task<ActionResult> GetEstadoCivil()
        {
            var result = await EstadoCivilBusiness.GetEstadoCivil();
            return StatusCode(result.Code, result);
        }
        #endregion

    }
}
