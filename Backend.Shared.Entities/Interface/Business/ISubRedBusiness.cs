using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Shared.Entities.Interface.Business
{ 
    /// <summary>
    /// ISubRedBusiness
    /// </summary>
    public interface ISubRedBusiness
    {
        /// <summary>
        /// Get SubRed .
        /// </summary>
        /// <returns></returns>
        Task<Entities.Responses.ResponseBase<List<Entities.Models.Commons.SubRed>>> GetSubRed();

    }
}