using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using RL201130Desafio2.BL.Interfaces;
using RL201130Desafio2.DAL.Interfaces;
using RL201130Desafio2.Entities.DTO;
using RL201130Desafio2.Entities.Models;

namespace RL201130Desafio2.BL
{
    public class CursoService : ICursoService
    {
        private readonly ICursoRepository _cursoRepository;
        private readonly IMapper _mapper;

        public CursoService(ICursoRepository cursoRepository, IMapper mapper)
        {
            _cursoRepository = cursoRepository;
            _mapper = mapper;
        }

        public async Task<List<CursoDto>> GetCursosAsync()
        {
            try
            {
                var result = await _cursoRepository.GetCursosAsync();
                return _mapper.Map<List<Curso>, List<CursoDto>>(result);
            }
            catch (Exception)
            {
                return new List<CursoDto>();
            }
        }

        public async Task<CursoDto> GetCursoByIdAsync(int id)
        {
            try
            {
                var result = await _cursoRepository.GetCursoByIdAsync(id);
                return _mapper.Map<Curso, CursoDto>(result);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<int> InsertCursoAsync(CursoDto model)
        {
            try
            {
                // Validar que el instructor exista
                bool instructorExists = await _cursoRepository.InstructorExistsAsync(model.IdInstructor);
                if (!instructorExists)
                {
                    throw new Exception("El instructor especificado no existe");
                }

                // Validar que el nivel sea válido
                if (model.NivelCurso != "Básico" && model.NivelCurso != "Intermedio" && model.NivelCurso != "Avanzado")
                {
                    throw new Exception("El nivel debe ser Básico, Intermedio o Avanzado");
                }

                var entity = _mapper.Map<CursoDto, Curso>(model);
                return await _cursoRepository.InsertCursoAsync(entity);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar curso: " + ex.Message);
            }
        }

        public async Task<CursoDto> UpdateCursoAsync(CursoDto model)
        {
            try
            {
                // Validar que el instructor exista
                bool instructorExists = await _cursoRepository.InstructorExistsAsync(model.IdInstructor);
                if (!instructorExists)
                {
                    throw new Exception("El instructor especificado no existe");
                }

                // Validar que el nivel sea válido
                if (model.NivelCurso != "Básico" && model.NivelCurso != "Intermedio" && model.NivelCurso != "Avanzado")
                {
                    throw new Exception("El nivel debe ser Básico, Intermedio o Avanzado");
                }

                var entity = _mapper.Map<CursoDto, Curso>(model);
                var result = await _cursoRepository.UpdateCursoAsync(entity);
                return _mapper.Map<Curso, CursoDto>(result);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar curso: " + ex.Message);
            }
        }

        public async Task<bool> DeleteCursoAsync(int id)
        {
            try
            {
                return await _cursoRepository.DeleteCursoAsync(id);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}