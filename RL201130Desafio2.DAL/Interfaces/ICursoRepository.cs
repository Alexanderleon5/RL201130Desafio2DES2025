using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RL201130Desafio2.Entities.Models;

namespace RL201130Desafio2.DAL.Interfaces
{
    public interface ICursoRepository
    {
        Task<List<Curso>> GetCursosAsync();
        Task<Curso> GetCursoByIdAsync(int id);
        Task<int> InsertCursoAsync(Curso curso);
        Task<Curso> UpdateCursoAsync(Curso curso);
        Task<bool> DeleteCursoAsync(int id);
        Task<bool> InstructorExistsAsync(int idInstructor);
    }
}