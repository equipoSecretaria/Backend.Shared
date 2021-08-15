namespace Backend.Shared.Entities.Models.Tramites
{
    public partial class PrMunicipio
    {
        public int IdMunicipio { get; set; }
        public int IdDepartamento { get; set; }
        public string CodigoDane { get; set; }
        public string Descripcion { get; set; }
    }
}
