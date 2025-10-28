using AutoMapper;
using FilmesApi.Data.DTOs;
using FilmesApi.Models;

namespace FilmesApi.Profiles
{
    public class FilmeProfile : Profile
    {
        public FilmeProfile()
        {
            // Classe que serve para criar o perfil de mapeamento de CreateFilmeDto para um filme utilizando a lib AutoMapper.
            // A versão mais nova do AutoMapper injection não funciona, então aconselho baixar ambas as versões da lib do motor e da injection na 12.0
            CreateMap<CreateFilmeDto, Filme>(); // Por padrão, o AutoMapper assume que propriedades com o mesmo nome devem ser copiadas
            CreateMap<UpdateFilmeDto, Filme>();
            CreateMap<Filme, UpdateFilmeDto>();
            CreateMap<Filme, ReadFilmeDto>();
        }
    }
}
