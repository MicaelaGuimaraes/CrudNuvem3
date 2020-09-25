using CrudNuvemTheree.DataAccess.Context;
using CrudNuvemTheree.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CrudNuvemTheree.DataAccess.Repository
{
    public class RepositoryBase<TEntity> : IDisposable, IRepository<TEntity> where TEntity : class
    {
        protected Contexto Db = new Contexto();

        public void Add(TEntity obj)
        {
            try
            {
                Db.Database.Log = (s) => System.Diagnostics.Debug.Write(s);
                Db.Set<TEntity>().Add(obj);
                Db.SaveChanges();
            }
            catch (Exception ex)
            {

            }
        }

        public TEntity GetById(int id)
        {
            Db.Database.Log = (s) => System.Diagnostics.Debug.Write(s);
            return Db.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            Db.Database.Log = (s) => System.Diagnostics.Debug.Write(s);
            return Db.Set<TEntity>().ToList();
        }

        public void Update(TEntity obj)
        {
            Db.Database.Log = (s) => System.Diagnostics.Debug.Write(s);
            Db.Entry(obj).State = EntityState.Modified;
            Db.SaveChanges();
        }

        public void Remove(TEntity obj)
        {
            Db.Database.Log = (s) => System.Diagnostics.Debug.Write(s);
            Db.Entry(obj).State = EntityState.Deleted;
            Db.Set<TEntity>().Remove(obj);
            Db.SaveChanges();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, Boolean>> filtro)
        {
            Db.Database.Log = (s) => System.Diagnostics.Debug.Write(s);
            return Db.Set<TEntity>().AsNoTracking().Where(filtro).ToList();
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }

}
