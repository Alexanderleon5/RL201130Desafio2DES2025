using Microsoft.Extensions.DependencyInjection;
using RL201130Desafio2.BL.Automapper;
using RL201130Desafio2.BL.Interfaces;
using RL201130Desafio2.DAL.Services;

namespace RL201130Desafio2.BL.Services
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServiceConnector(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutomapperProfile).Assembly);
            services.AddTransient<IInstructorService, InstructorService>();
            services.AddTransient<IEstudianteService, EstudianteService>();
            services.AddTransient<ICursoService, CursoService>();
            services.AddTransient<IInscripcionService, InscripcionService>();
            services.AddRepositoryConnector();
            return services;
        }
    }
}