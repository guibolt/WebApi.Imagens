using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace WebApi.Imagens.Data.Interfaces
{
    public interface IDocumentRepository
    {
   
        bool Insere<T>(T entity, string collectionName) where T : new();
        bool Deletar<T>(Guid id, string collectionName) where T : new();

        List<T> BuscarLista<T>(string collectionName) where T : new();

        bool Atualizar<T>(T entity, string collectionName) where T : new();

        T Buscar<T>(Expression<Func<T, bool>> predicate, string collectionName) where T : new();

    }
}
