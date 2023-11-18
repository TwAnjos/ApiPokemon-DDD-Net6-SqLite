using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Utils.InterfaceGenerics
{
    public interface IGeneric<T> where T : class
    {
        Task Add(T entity);
        Task Add(List<T> entities);
        Task Update(T entity);
        Task Delete(T entity);
        Task<T> GetEntityById(int Id);
        Task<List<T>> GetAll();
    }
}
