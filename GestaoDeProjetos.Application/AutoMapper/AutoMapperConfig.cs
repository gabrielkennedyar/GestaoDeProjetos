using AutoMapper;
using GestaoDeProjetos.Application.ViewModels;
using GestaoDeProjetos.Domain.Entities;

namespace GestaoDeProjetos.Application.AutoMapper
{
    public class AutoMapperConfig
    {
        public static IMapper RegisterMappings()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Equipe, EquipeViewModel>().ReverseMap();
                cfg.CreateMap<Pessoa, PessoaViewModel>().ReverseMap();
                cfg.CreateMap<PessoaEquipe, PessoaEquipeViewModel>().ReverseMap();
                cfg.CreateMap<Projeto, ProjetoViewModel>().ReverseMap();
                cfg.CreateMap<Tarefa, TarefaViewModel>().ReverseMap();
            });

            IMapper mapper = config.CreateMapper();
            return mapper;
        }
    }
}
