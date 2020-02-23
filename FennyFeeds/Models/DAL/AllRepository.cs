using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FennyFeeds.Models.DAL
{
    public class AllRepository<T>:_IAllRepository<T> where T:class
    {
        private DataContext _context;
        private IDbSet<T> dbEntity;

        public AllRepository()
        {
            _context = new DataContext();
            dbEntity = _context.Set<T>();
        }

        public IEnumerable<T> GetModel()
        {
            return dbEntity.ToList();
        }

        public T GetModelById(int modelId)
        {
            return dbEntity.Find(modelId);
        }

        public void InsertModel(T model)
        {
            dbEntity.Add(model);
        }

        public void DeleteModel(int modelId)
        {
            T model = dbEntity.Find(modelId);
            dbEntity.Remove(model);
        }

        public void UpdateModel(T model)
        {
            _context.Entry(model).State = System.Data.EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}