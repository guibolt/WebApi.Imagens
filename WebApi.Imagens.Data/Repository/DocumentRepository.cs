using LiteDB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using WebApi.Imagens.Data.Interfaces;

namespace WebApi.Imagens.Data.Repository
{
    public class DocumentRepository : IDocument
    {
#if DEBUG 
        private readonly string _dbPath = AppDomain.CurrentDomain.FriendlyName;
#else
       private readonly string _dbPath = @"D:\\data\\arquivo.db";
#endif

        public bool Delete<T>(Guid id, string collectionName) where T : new()
        {
            try
            {
                using var db = new LiteDatabase(_dbPath);
                var col = db.GetCollection<T>(collectionName);
                col.Delete(id);
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public List<T> GetData<T>(string collectionName) where T : new()
        {
           
                using var db = new LiteDatabase(_dbPath);
                var colList = db.GetCollection<T>(collectionName).FindAll().ToList();

                return colList;
        }

        public bool Salva<T>(T entity, string collectionName) where T : new()
        {
            try
            {
                using var db = new LiteDatabase(_dbPath);
                var col = db.GetCollection<T>(collectionName);
                col.Insert(entity);


                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public bool Update<T>(T entity, string collectionName) where T : new()
        {
            try
            {
                using var db = new LiteDatabase(_dbPath);
                var col = db.GetCollection<T>(collectionName);
                col.Update(entity);

                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }
    }
}
