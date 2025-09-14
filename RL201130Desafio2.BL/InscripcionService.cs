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
    public class InscripcionService : IInscripcionService
    {
        private readonly IInscripcionRepository _inscripcionRepository;
        private readonly IMapper _mapper;

        public InscripcionService(IInscripcionRepository inscripcionRepository, IMapper mapper)
        {
            _inscripcionRepository = inscripcionRepository;
            _mapper = mapper;
        }

        public async Task<List<InscripcionDto>> GetInscripcionesAsync()
        {
            try
            {
                var result = await _inscripcionRepository.GetInscripcionesAsync();
                return _mapper.Map<List<Inscripcion>, List<InscripcionDto>>(result);
            }
            catch (Exception)
            {
                return new List<InscripcionDto>();
            }
        }

        public async Task<InscripcionDto> GetInscripcionByIdAsync(int id)
        {
            try
            {
                var result = await _inscripcionRepository.GetInscripcionByIdAsync(id);
                return _mapper.Map<Inscripcion, InscripcionDto>(result);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<int> InsertInscripcionAsync(InscripcionDto model)
        {
            try
            {
                // Validar que no exista una inscripción duplicada
                bool inscripcionExists = await _inscripcionRepository.InscripcionExistsAsync(model.IdEstudiante, model.IdCurso);
                if (inscripcionExists)
                {
                    throw new Exception("El estudiante ya está inscrito en este curso");
                }

                var entity = _mapper.Map<InscripcionDto, Inscripcion>(model);
                return await _inscripcionRepository.InsertInscripcionAsync(entity);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar inscripción: " + ex.Message);
            }
        }

        public async Task<InscripcionDto> UpdateInscripcionAsync(InscripcionDto model)
        {
            try
            {
                // Validar que no exista una inscripción duplicada (excluyendo la actual)
                bool inscripcionExists = await _inscripcionRepository.InscripcionExistsAsync(model.IdEstudiante, model.IdCurso);
                if (inscripcionExists)
                {
                    // Obtener la inscripción existente para verificar si es la misma que estamos editando
                    var existingInscripciones = await _inscripcionRepository.GetInscripcionesAsync();
                    var duplicate = existingInscripciones.FirstOrDefault(i =>
                        i.IdEstudiante == model.IdEstudiante &&
                        i.IdCurso == model.IdCurso &&
                        i.IdInscripcion != model.Codigo);

                    if (duplicate != null)
                    {
                        throw new Exception("El estudiante ya está inscrito en este curso");
                    }
                }

                var entity = _mapper.Map<InscripcionDto, Inscripcion>(model);
                var result = await _inscripcionRepository.UpdateInscripcionAsync(entity);
                return _mapper.Map<Inscripcion, InscripcionDto>(result);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar inscripción: " + ex.Message);
            }
        }

        public async Task<bool> DeleteInscripcionAsync(int id)
        {
            try
            {
                return await _inscripcionRepository.DeleteInscripcionAsync(id);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}