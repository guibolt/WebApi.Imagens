using LiteDB;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using WebApi.Imagens.Data.Context;
using WebApi.Imagens.Data.Interfaces;

namespace WebApi.Imagens.Data.Repository
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly ILiteDbContext _liteDbContext;
        private readonly LiteDatabase _bancoDeDados;

        public DocumentRepository(ILiteDbContext liteDbContext)
        {
            _liteDbContext = liteDbContext;
            _bancoDeDados = _liteDbContext.BuscaDatabase();
        }

        public bool Atualizar<T>(T entity, string collectionName) where T : new()
        {
            try
            {
                var collection = _bancoDeDados.GetCollection<T>(collectionName);

                 var atualizou =  collection.Update(entity);

                return atualizou;

            }
            catch (Exception ex)
            {
                Debug.Write(ex);
                return false;
            }

        }

        public T Buscar<T>(Expression<Func<T, bool>> predicate, string collectionName) where T : new()
        {
            try
            {
                var collection = _bancoDeDados.GetCollection<T>(collectionName);

                var resultadoBusca = collection.Find(predicate).FirstOrDefault();
                return resultadoBusca;

            }
            catch (Exception ex)
            {
                Debug.Write(ex);
                return new T();
            }
        }

        public List<T> BuscarLista<T>(string collectionName) where T : new()
        {
            try
            {
                var collection = _bancoDeDados.GetCollection<T>(collectionName);

                var list = collection.FindAll().ToList();

                return list;
            }
            catch (Exception ex)
            {
                Debug.Write(ex);
                return null;
            }
        }

        public bool Deletar<T>(Guid id, string collectionName) where T : new()
        {
            try
            {
                var collection = _bancoDeDados.GetCollection<T>(collectionName);

                var deletou = collection.Delete(id);

                return true;
            }
            catch (Exception ex)
            {
                Debug.Write(ex);
                return false;
            }
        }

        public bool Insere<T>(T entity, string collectionName) where T : new()
        {
            try
            {
                var collection = _bancoDeDados.GetCollection<T>(collectionName);

              collection.Insert(entity);

                return true;

            }
            catch (Exception ex)
            {
                Debug.Write(ex);
                return false;
            }
        }
    }
}
