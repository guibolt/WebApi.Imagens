using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Imagens.Api.Model
{
    public class BuscarImagemInputModel
    {
        public string TipoRecurso { get; set; }
        public int IdImagem { get; set; }
    }
}
