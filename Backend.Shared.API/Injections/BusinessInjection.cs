using Backend.Shared.BusinessRules;
using Backend.Shared.Entities.Interface.Business;
using Microsoft.Extensions.DependencyInjection;

namespace Backend.Shared.API.Injections
{
    /// <summary>
    /// Business Injection
    /// </summary>
    public static class BusinessInjection
    {
        /// <summary>
        /// Adds the business configuration.
        /// </summary>
        /// <param name="services">The services.</param>
        public static void AddBusinessConfig(this IServiceCollection services)
        {
            services.AddTransient<ITipoIdentificacionBusiness, TipoIdentificacionBusiness>();
            services.AddTransient<IPaisBusiness, PaisBusiness>();
            services.AddTransient<IDepartamentoBusiness, DepartamentoBusiness>();
            services.AddTransient<IEtniaBusiness, EtniaBusiness>();
            services.AddTransient<IEstadoCivilBusiness, EstadoCivilBusiness>();
            services.AddTransient<INivelEducativoBusiness, NivelEducativoBusiness>();
            services.AddTransient<ISexoBusiness, SexoBusiness>();
            services.AddTransient<IFunerariaBusiness, FunerariaBusiness>();
            services.AddTransient<IProfesionalesSaludBusiness, ProfesionalesSaludBusiness>();
            services.AddTransient<ICementerioBusiness, CementerioBusiness>();
            services.AddTransient<IInstitucionBusiness, InstitucionBusiness>();
            services.AddTransient<IDominioBusiness, DominioBusiness>();
            services.AddTransient<IMunicipioBusiness, MunicipioBusiness>();
            services.AddTransient<ILocalidadBusiness, LocalidadBusiness>();
            services.AddTransient<IUpzBusiness, UpzBusiness>();
            services.AddTransient<IBarrioBusiness, BarrioBusiness>();
            services.AddTransient<ICertificadoDefuncionBusiness, CertificadoDefuncionBusiness>();
            services.AddTransient<IPersonaBusiness, PersonaBusiness>();
        }
    }
}
