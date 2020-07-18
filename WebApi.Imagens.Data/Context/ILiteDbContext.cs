using LiteDB;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.Imagens.Data.Context
{
    public interface ILiteDbContext
    {
        public LiteDatabase BuscaDatabase();
    }
}
