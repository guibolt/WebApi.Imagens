using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace WebApi.Imagens.Data.Interfaces
{
    public interface IDocumentExactSearchRepository
    {
        List<T> GetData<T>(
                    string collectionName,
                    Expression<Func<T, bool>> predicate,
                    int skip,
                    int limit,
                    Func<T, object> orderBy
            ) where T : new();
        bool Delete<T>(
           T entity,
           string collectionName,
           Expression<Func<T, bool>> predicate) where T : new();
    }
}
