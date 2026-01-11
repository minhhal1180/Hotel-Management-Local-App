using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace LibraryManagementSystem.DAL.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        // Lấy danh sách có điều kiện lọc (filter), sắp xếp (orderBy) và kèm bảng phụ (includeProperties)
        IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            string includeProperties = "");

        T? GetByID(object id);

        void Insert(T entity);

        void Delete(object id);

        void Delete(T entityToDelete);

        void Update(T entityToUpdate);
    }
}