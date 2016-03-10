using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Consultancy.Project.Repository
{
    public interface IGenericRepository<T> where T :class
    {
        void Insert(T t);
        void Update(T t);
        void Delete(int id);
        T GetById(int id);
        IEnumerable<T> GetAll();
        List<T> Search(Expression<Func<T>> t);
    }
}
