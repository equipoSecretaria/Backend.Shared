using System;

namespace Backend.Shared.Entities.DTOs
{
    public class PersonaVentanillaDTO
    {
        public long NumeroIdentificacion { get; set; }
        public string FullName { get; set; }
        public string RazonSocial { get; set; }

        //JENEGUI -EMRO Atributos para Tramite Opticas
        //Persona Natural
        public long TipoIdentificacion { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Email { get; set; }
        public string TelefonoFijo { get; set; }
        public string TelefonoCelular { get; set; }

        //Persona Juridica Representante Legal

        public long TipoIdentificacionRL { get; set; }
        public Int32? NumeroIdentificacionRL { get; set; }
        



    }
}
