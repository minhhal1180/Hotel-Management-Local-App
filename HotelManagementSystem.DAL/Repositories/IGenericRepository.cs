using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HotelManagementSystem.DAL.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        // Lấy danh sách có điều kiện lọc (filter), sắp xếp (orderBy) và kèm bảng phụ (includeProperties)
        IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            string includeProperties = "");

        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            string includeProperties = "");

        T? GetByID(object id);
        Task<T?> GetByIDAsync(object id);

        void Insert(T entity);

        void Delete(object id);
        Task DeleteAsync(object id);

        void Delete(T entityToDelete);

        void Update(T entityToUpdate);
    }
}
