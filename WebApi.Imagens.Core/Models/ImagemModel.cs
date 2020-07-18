using LiteDB;
using System;

namespace WebApi.Imagens.Core.Models
{
    public class ImagemModel
    {
        [BsonId]
        public Guid Id { get; set; }
        public string ImageId { get; set; }
        public string Data64 { get; set; }
        public string NomeArquivo { get; set; }
        public DateTime DataInclusao { get; set; } 
    }
}
