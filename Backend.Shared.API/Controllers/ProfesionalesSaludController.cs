using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Backend.Shared.API.Controllers
{
    /// <summary>
    /// ProfesionalesSaludController
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [ApiController, Route("api/v1/[controller]")]
    public class ProfesionalesSaludController : ControllerBase
    {
        #region Attributes                
        /// <summary>
        /// The profesionales salud business
        /// </summary>
        private readonly Entities.Interface.Business.IProfesionalesSaludBusiness ProfesionalesSaludBusiness;
        #endregion

        #region Constructor                                                                                     
        /// <summary>
        /// Initializes a new instance of the <see cref="ProfesionalesSaludController"/> class.
        /// </summary>
        /// <param name="profesionalesSaludBusiness">The profesionales salud business.</param>
        public ProfesionalesSaludController(Entities.Interface.Business.IProfesionalesSaludBusiness profesionalesSaludBusiness)
        {
            ProfesionalesSaludBusiness = profesionalesSaludBusiness;
        }
        #endregion

        #region Methods                        
        /// <summary>
        /// Gets the profesional salud by numero identificacion.
        /// </summary>
        /// <param name="numeroIdentificacion">The numero identificacion.</param>
        /// <returns></returns>
        [HttpGet("GetProfesionalSaludByNumeroIdentificacion/{numeroIdentificacion}")]
        public async Task<ActionResult> GetProfesionalSaludByNumeroIdentificacion(string numeroIdentificacion)
        {
            var result = await ProfesionalesSaludBusiness.GetProfesionalSaludByNumeroIdentificacion(numeroIdentificacion);
            return StatusCode(result.Code, result);
        }
        #endregion
    }
}
