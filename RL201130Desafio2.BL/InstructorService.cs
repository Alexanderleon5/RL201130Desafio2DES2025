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
    public class InstructorService : IInstructorService
    {
        private readonly IInstructorRepository _repository;
        private readonly IMapper _mapper;
        public InstructorService(IInstructorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<InstructorDto>> GetInstructoresAsync()
        {
            try
            {
                var result = await _repository.GetInstructoresAsync();
                return _mapper.Map<List<Instructor>, List<InstructorDto>>(result);
            }
            catch (Exception)
            {
                return new List<InstructorDto>();
            }
        }
        public async Task<InstructorDto> GetInstructorByIdAsync(int id)
        {
            try
            {
                var result = await _repository.GetInstructorByIdAsync(id);
                return _mapper.Map<Instructor, InstructorDto>(result);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<int> InsertInstructorAsync(InstructorDto model)
        {
            try
            {
                var entity = _mapper.Map<InstructorDto, Instructor>(model);
                return await _repository.InsertInstructorAsync(entity);
            }
            catch (Exception)
            {
                return -1;
            }
        }
        public async Task<InstructorDto> UpdateInstructorAsync(InstructorDto model)
        {
            try
            {
                var entity = _mapper.Map<InstructorDto, Instructor>(model);
                var result = await _repository.UpdateInstructorAsync(entity);
                return _mapper.Map<Instructor, InstructorDto>(result);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<bool> DeleteInstructorAsync(int id)
        {
            try
            {
                return await _repository.DeleteInstructorAsync(id);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}