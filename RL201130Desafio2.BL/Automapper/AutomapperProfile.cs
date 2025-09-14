using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using RL201130Desafio2.Entities.DTO;
using RL201130Desafio2.Entities.Models;

namespace RL201130Desafio2.BL.Automapper
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Instructor, InstructorDto>()
                .ForMember(dest => dest.Codigo, opt => opt.MapFrom(src => src.IdInstructor))
                .ForMember(dest => dest.NombreInstructor, opt => opt.MapFrom(src => src.Nombre))
                .ForMember(dest => dest.EspecialidadInstructor, opt => opt.MapFrom(src => src.Especialidad))
                .ForMember(dest => dest.EmailInstructor, opt => opt.MapFrom(src => src.Email))
                .ReverseMap();

            CreateMap<Estudiante, EstudianteDto>()
                .ForMember(dest => dest.Codigo, opt => opt.MapFrom(src => src.IdEstudiante))
                .ForMember(dest => dest.NombreEstudiante, opt => opt.MapFrom(src => src.Nombre))
                .ForMember(dest => dest.EmailEstudiante, opt => opt.MapFrom(src => src.Email))
                .ReverseMap();

            CreateMap<Curso, CursoDto>()
                .ForMember(dest => dest.Codigo, opt => opt.MapFrom(src => src.IdCurso))
                .ForMember(dest => dest.TituloCurso, opt => opt.MapFrom(src => src.Titulo))
                .ForMember(dest => dest.DescripcionCurso, opt => opt.MapFrom(src => src.Descripcion))
                .ForMember(dest => dest.NivelCurso, opt => opt.MapFrom(src => src.Nivel))
                .ReverseMap();

            CreateMap<Inscripcion, InscripcionDto>()
                .ForMember(dest => dest.Codigo, opt => opt.MapFrom(src => src.IdInscripcion))
                .ReverseMap();
        }
    }
}