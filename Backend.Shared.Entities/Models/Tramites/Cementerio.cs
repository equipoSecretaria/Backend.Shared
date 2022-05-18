using System;

namespace Backend.Shared.Entities.Models.Tramites
{
    public partial class Cementerio
    {
        public int NROIDENT { get; set; }
        public string TIPO_I { get; set; }
        public string RAZON_S { get; set; }
        public string DIRECCION { get; set; }
        public string TELEFONO_1 { get; set; }
        public string TELEFONO_2 { get; set; }
        public string TIPO_I_REP { get; set; }
        public string NROIDENT_REP { get; set; }
        public string NOMBRE_REP { get; set; }
        public string CREMACION { get; set; }
    }
}