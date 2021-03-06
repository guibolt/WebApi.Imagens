using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebApi.Imagens.Tests.FakeObjects
{
    class ArquivoFake : IFormFile
    {
        public string ContentType => "JPG";

        public string ContentDisposition => "ALGO";

        public IHeaderDictionary Headers => throw new NotImplementedException();

        public long Length => 46546;

        public string Name => "jAILSIN.JPG";

        public string FileName => "jAILSIN.JPG";

        public void CopyTo(Stream target)
        {
            
        }

        public Task CopyToAsync(Stream target, CancellationToken cancellationToken = default)
        {
            return null;
        }

        public Stream OpenReadStream()
        {
            return null;
        }
    }
}
