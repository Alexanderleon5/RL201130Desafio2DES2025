using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RL201130Desafio2.Entities.Models;

namespace RL201130Desafio2.DAL.Interfaces
{
    public interface IInscripcionRepository
    {
        Task<List<Inscripcion>> GetInscripcionesAsync();
        Task<Inscripcion> GetInscripcionByIdAsync(int id);
        Task<int> InsertInscripcionAsync(Inscripcion inscripcion);
        Task<Inscripcion> UpdateInscripcionAsync(Inscripcion inscripcion);
        Task<bool> DeleteInscripcionAsync(int id);
        Task<bool> InscripcionExistsAsync(int idEstudiante, int idCurso);
    }
}