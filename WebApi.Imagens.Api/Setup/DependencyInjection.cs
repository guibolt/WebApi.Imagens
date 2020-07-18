using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Imagens.Data.Context;
using WebApi.Imagens.Data.Interfaces;
using WebApi.Imagens.Data.Repository;
using WebApi.Imagens.Service.Inclusao.Services;


namespace WebApi.Imagens.Api.Setup
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            //Services
            services.AddTransient<IAdicaoService, AdicaoService>();

            //Data
            services.AddTransient<IDocumentRepository, DocumentRepository>();


#if DEBUG
            services.AddSingleton<ILiteDbContext>(new LiteDbContext(string.Format("{0}/{1}",Environment.CurrentDirectory,"/Data/DataBase.db")));
#else
            //Context
            //  services.AddSingleton<ILiteDbContext>(new LiteDbContext( string.Format("{0}{1}", Environment.CurrentDirectory, configuration.GetSection("LiteDbOptions").GetSection("DatabaseLocation").Value)));
            services.AddSingleton<ILiteDbContext>(new LiteDbContext(@"D:\home\site\wwwroot\banco.db"));

#endif

        }
    }
}
