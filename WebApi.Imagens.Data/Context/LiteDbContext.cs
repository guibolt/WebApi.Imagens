using LiteDB;

namespace WebApi.Imagens.Data.Context
{
    public class LiteDbContext : ILiteDbContext
    {
        private readonly LiteDatabase _database;
        public LiteDbContext(string dataBaseLocation) =>  _database = new LiteDatabase(dataBaseLocation);
        public LiteDatabase BuscaDatabase() => _database;
      
    }
}
