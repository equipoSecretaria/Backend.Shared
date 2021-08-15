using System;
using System.ComponentModel.DataAnnotations;

namespace Backend.Shared.Entities.DTOs.v2
{
    public class RequestUserRoleDTO
    {
        [Required(ErrorMessage = "El campo es obligatorio")]
        [DataType(DataType.Text)]
        public Guid IdUser { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio")]
        [DataType(DataType.Text)]
        public Guid IdRole { get; set; }
    }
}
