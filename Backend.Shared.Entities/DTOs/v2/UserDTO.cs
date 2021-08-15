using System;
using System.ComponentModel.DataAnnotations;

namespace Backend.Shared.Entities.DTOs.v2
{
    public class UserDTO
    {
        [Required(ErrorMessage = "El campo es obligatorio")]
        [DataType(DataType.Text)]
        public Guid Oid { get; set; }

        [Required(ErrorMessage = "El campo es obligatorio")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
