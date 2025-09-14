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
    public class EstudianteService : IEstudianteService
    {
        private readonly IEstudianteRepository _repository;
        private readonly IMapper _mapper;

        public EstudianteService(IEstudianteRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<EstudianteDto>> GetEstudiantesAsync()
        {
            try
            {
                var result = await _repository.GetEstudiantesAsync();
                return _mapper.Map<List<Estudiante>, List<EstudianteDto>>(result);
            }
            catch (Exception)
            {
                return new List<EstudianteDto>();
            }
        }

        public async Task<EstudianteDto> GetEstudianteByIdAsync(int id)
        {
            try
            {
                var result = await _repository.GetEstudianteByIdAsync(id);
                return _mapper.Map<Estudiante, EstudianteDto>(result);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<int> InsertEstudianteAsync(EstudianteDto model)
        {
            try
            {
                var entity = _mapper.Map<EstudianteDto, Estudiante>(model);
                return await _repository.InsertEstudianteAsync(entity);
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public async Task<EstudianteDto> UpdateEstudianteAsync(EstudianteDto model)
        {
            try
            {
                var entity = _mapper.Map<EstudianteDto, Estudiante>(model);
                var result = await _repository.UpdateEstudianteAsync(entity);
                return _mapper.Map<Estudiante, EstudianteDto>(result);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<bool> DeleteEstudianteAsync(int id)
        {
            try
            {
                return await _repository.DeleteEstudianteAsync(id);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}