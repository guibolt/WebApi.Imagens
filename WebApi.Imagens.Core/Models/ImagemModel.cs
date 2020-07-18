using LiteDB;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.Imagens.Core.Models
{
    public class ImagemModel
    {
        [BsonId]
        public Guid Id { get; set; }
        public string Data64 { get; set; }
        public string NomeArquivo { get; set; }
        public DateTime DataInclusao { get; set; } 
    }
}
