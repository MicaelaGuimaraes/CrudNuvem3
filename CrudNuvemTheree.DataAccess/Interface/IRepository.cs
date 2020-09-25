using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CrudNuvemTheree.DataAccess.Interface
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entidade);

        TEntity GetById(int id);

        IEnumerable<TEntity> GetAll();

        void Update(TEntity obj);

        void Remove(TEntity obj);

        IEnumerable<TEntity> Find(Expression<Func<TEntity, Boolean>> filtro);
    }
}
