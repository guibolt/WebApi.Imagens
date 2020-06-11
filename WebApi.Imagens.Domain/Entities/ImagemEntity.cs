using LiteDB;
using System;

namespace WebApi.Imagens.Domain.Entities
{
    public class ImagemEntity
    {
        [BsonId]
        public Guid Id { get; set; }
        public string NomeArquivo { get; set; }
        public string Data64 { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.Now;
    }
}
