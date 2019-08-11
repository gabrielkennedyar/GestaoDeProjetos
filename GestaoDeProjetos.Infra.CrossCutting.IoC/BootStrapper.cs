using GestaoDeProjetos.Infra.Data.Context;
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
    }
}
