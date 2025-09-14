using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RL201130Desafio2.Entities.DTO;

namespace RL201130Desafio2.BL.Interfaces
{
    public interface IEstudianteService
    {
        Task<List<EstudianteDto>> GetEstudiantesAsync();
        Task<EstudianteDto> GetEstudianteByIdAsync(int id);
        Task<int> InsertEstudianteAsync(EstudianteDto estudiante);
        Task<EstudianteDto> UpdateEstudianteAsync(EstudianteDto estudiante);
        Task<bool> DeleteEstudianteAsync(int id);
    }
}