using AutoMapper;
using FilmesApi.Data.DTOs;
using FilmesApi.Models;

namespace FilmesApi.Profiles
{
    public class CinemaProfile : Profile
    {
        public CinemaProfile()
        {
            CreateMap<CreateCinemaDto, Cinema>();
            CreateMap<Cinema, ReadCinemaDto>().ForMember(cinemaDto => cinemaDto.Endereco, opt => opt.MapFrom(cinema => cinema.Endereco)); // Está atribuindo ao campo "Endereco" de ReadCinemaDto o resultado da função ReadEnderecoDto. Ou seja, ao dar um GET no cinema, ele retornará todas as informações retornadas pelo read do endereço no campo do endereço, incluindo id, logradouro e número.
            CreateMap<Cinema, ReadCinemaDto>().ForMember(cinemaDto => cinemaDto.Sessoes, opt => opt.MapFrom(cinema => cinema.Sessoes));
            CreateMap<UpdateCinemaDto, Cinema>();
        }
    }
}
