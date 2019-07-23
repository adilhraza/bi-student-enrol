using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace StudentCourseApp.Data.Repository
{
    public interface IBaseRepository<T> where T : class
    {
        void Add(T entity);

        void AddRange(IEnumerable<T> entities);

        void Remove(T entity);

        void RemoveRange(IEnumerable<T> entities);

        void Update(T entity);

        void Save();

        T Get(int id);

        IEnumerable<T> GetAll();

        IEnumerable<T> GetPagedResults(int pageIndex, int pageSize);

        IEnumerable<T> Find(Expression<Func<T, bool>> predicatExpression);
    }
}