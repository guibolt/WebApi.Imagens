using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using WebApi.Imagens.Data.Context;
using WebApi.Imagens.Data.Interfaces;
using WebApi.Imagens.Data.Repository;
using WebApi.Imagens.Service.Consulta.Services.Classes;
using WebApi.Imagens.Service.Consulta.Services.Interfaces;
using WebApi.Imagens.Service.Delecao.Services.Classes;
using WebApi.Imagens.Service.Delecao.Services.Interfaces;
using WebApi.Imagens.Service.Inclusao.Services;


namespace WebApi.Imagens.Api.Setup
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            //Services
            services.AddTransient<IAdicaoService, AdicaoService>();
            services.AddTransient<IConsultaService, ConsultaService>();
            services.AddTransient<IDeletaImagemService, DeletaImagemService>();

            //Data
            services.AddTransient<IDocumentRepository, DocumentRepository>();

            //Context
#if DEBUG
            services.AddSingleton<ILiteDbContext>(new LiteDbContext(string.Format("{0}/{1}",Environment.CurrentDirectory,"/Data/DataBase.db")));
#else
           
            services.AddSingleton<ILiteDbContext>(new LiteDbContext(@"D:\home\site\wwwroot\DataBase.db"));

#endif

        }
    }
}
