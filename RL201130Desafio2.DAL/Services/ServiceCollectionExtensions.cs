using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using RL201130Desafio2.DAL.Interfaces;

namespace RL201130Desafio2.DAL.Services
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositoryConnector(this IServiceCollection services)
        {
            services.AddTransient<IDatabaseRepository, DatabaseRepository>();
            services.AddTransient<IInstructorRepository, InstructorRepository>();
            services.AddTransient<IEstudianteRepository, EstudianteRepository>();
            services.AddTransient<ICursoRepository, CursoRepository>();
            services.AddTransient<IInscripcionRepository, InscripcionRepository>();
            return services;
        }
    }
}