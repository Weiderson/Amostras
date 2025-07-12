using AutoMapper;
using ApiAmostras.Application.DTOs;
using ApiAmostras.Domain.Model;

namespace ApiAmostras.Application.Mapping
{
    public class MappingDTO : Profile
    {
        public MappingDTO()
        {
            CreateMap<Amostra, AmostraDTO>()
                .ReverseMap();

            CreateMap<Status, StatusDTO>()
                .ReverseMap();
           
            CreateMap<UsuarioDTO, Usuario>()
                .ReverseMap();
        }       
    }
}