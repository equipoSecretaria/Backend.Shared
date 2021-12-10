using System;

namespace Backend.Shared.Entities.DTOs.v2
{
    public class UserRoleDTO
    {
        public Guid CodigoUsuario { get; set; }
        public string Email { get; set; }
        public string Rol { get; set; }
        public Guid CodigoRol { get; set; }
        public string Descripcion { get; set; }
        public string Value { get; set; }
    }
}
