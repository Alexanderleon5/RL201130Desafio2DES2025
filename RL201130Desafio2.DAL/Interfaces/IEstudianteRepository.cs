using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RL201130Desafio2.Entities.Models;

namespace RL201130Desafio2.DAL.Interfaces
{
    public interface IEstudianteRepository
    {
        Task<List<Estudiante>> GetEstudiantesAsync();
        Task<Estudiante> GetEstudianteByIdAsync(int id);
        Task<int> InsertEstudianteAsync(Estudiante estudiante);
        Task<Estudiante> UpdateEstudianteAsync(Estudiante estudiante);
        Task<bool> DeleteEstudianteAsync(int id);
    }
}