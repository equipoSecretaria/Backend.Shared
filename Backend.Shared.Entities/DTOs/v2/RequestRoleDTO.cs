using System.ComponentModel.DataAnnotations;

namespace Backend.Shared.Entities.DTOs.v2
{
    public class RequestRoleDTO
    {
        [Required(ErrorMessage = "El campo es obligatorio")]
        [DataType(DataType.Text)]
        public string Description { get; set; }

        [Required(ErrorMessage = "El campo es obligatorio")]
        [DataType(DataType.Text)]
        public string DisplayName { get; set; }

        [Required(ErrorMessage = "El campo es obligatorio")]
        [DataType(DataType.Text)]
        public string Value { get; set; }
    }
}
