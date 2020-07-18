using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Imagens.Api.Helpers
{
    public static class ImageHelper
    {

        public static string RetornaBase64(IFormFile arquivo)
        {
            string base64 = "";
            using (var ms = new MemoryStream())
            {
                arquivo.CopyTo(ms);
                var fileContent_ = ms.ToArray();
                base64 = Convert.ToBase64String(fileContent_);
            }

            return base64;
        }
    }
}
