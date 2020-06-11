using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace WebApi.Imagens.Data.Interfaces
{
    public interface IDocument
    {
        bool Salva<T>(T entity, string collectionName) where T : new();
        bool Delete<T>(Guid id, string collectionName) where T : new();

        List<T> GetData<T>(string collectionName) where T : new();
        bool Update<T>(T entity, string collectionName) where T : new();
    }
}
