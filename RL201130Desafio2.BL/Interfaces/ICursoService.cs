using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RL201130Desafio2.Entities.DTO;

namespace RL201130Desafio2.BL.Interfaces
{
    public interface ICursoService
    {
        Task<List<CursoDto>> GetCursosAsync();
        Task<CursoDto> GetCursoByIdAsync(int id);
        Task<int> InsertCursoAsync(CursoDto curso);
        Task<CursoDto> UpdateCursoAsync(CursoDto curso);
        Task<bool> DeleteCursoAsync(int id);
    }
}