using GestaoDeProjetos.Application.AppServices;
using GestaoDeProjetos.Application.IAppServices;
using GestaoDeProjetos.Domain.Interfaces.IRepositories;
using GestaoDeProjetos.Domain.Interfaces.IServices;
using GestaoDeProjetos.Domain.Interfaces.IUoW;
using GestaoDeProjetos.Domain.Services;
using GestaoDeProjetos.Infra.Data.Context;
using GestaoDeProjetos.Infra.Data.Repositories;
using GestaoDeProjetos.Infra.Data.UoW;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GestaoDeProjetos.Infra.CrossCutting.IoC
{
    public class BootStrapper
    {
        // Lifestyle.Transient => Uma instancia para cada solicitacao;
        // Lifestyle.Singleton => Uma instancia unica para a classe (para o servidor)
        // Lifestyle.Scoped => Uma instancia unica para o request

        public static void RegisterDbContext(IConfiguration configuration, IServiceCollection services)
        {
            services.AddDbContext<GestaoDeProjetosContext>(options => options.UseMySQL(configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Scoped);
        }
        public static void Register(IServiceCollection services)
        {
            // AppService
            services.AddScoped<IEquipeAppService, EquipeAppService>();
            services.AddScoped<IPessoaEquipeAppService, PessoaEquipeAppService>();
            services.AddScoped<IPessoaAppService, PessoaAppService>();
            services.AddScoped<IProjetoAppService, ProjetoAppService>();
            services.AddScoped<ITarefaAppService, TarefaAppService>();

            // Domain
            services.AddScoped<IEquipeService, EquipeService>();
            services.AddScoped<IPessoaEquipeService, PessoaEquipeService>();
            services.AddScoped<IPessoaService, PessoaService>();
            services.AddScoped<IProjetoService, ProjetoService>();
            services.AddScoped<ITarefaService, TarefaService>();

            // Infra Data
            services.AddScoped<IEquipeRepository, EquipeRepository>();
            services.AddScoped<IPessoaEquipeRepository, PessoaEquipeRepository>();
            services.AddScoped<IPessoaRepository, PessoaRepository>();
            services.AddScoped<IProjetoRepository, ProjetoRepository>();
            services.AddScoped<ITarefaRepository, TarefaRepository>();

            services.AddScoped<IUnityOfWork, UnityOfWork>();
        }
    }
}
