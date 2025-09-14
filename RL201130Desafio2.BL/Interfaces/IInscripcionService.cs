    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RL201130Desafio2.Entities.DTO;

namespace RL201130Desafio2.BL.Interfaces
{
    public interface IInscripcionService
    {
        Task<List<InscripcionDto>> GetInscripcionesAsync();
        Task<InscripcionDto> GetInscripcionByIdAsync(int id);
        Task<int> InsertInscripcionAsync(InscripcionDto inscripcion);
        Task<InscripcionDto> UpdateInscripcionAsync(InscripcionDto inscripcion);
        Task<bool> DeleteInscripcionAsync(int id);
    }
}