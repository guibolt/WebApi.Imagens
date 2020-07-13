using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Imagens.Service.Inclusao.Services;


namespace WebApi.Imagens.Api.Setup
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IAdicaoService, AdicaoService>();


        }
    }
}
