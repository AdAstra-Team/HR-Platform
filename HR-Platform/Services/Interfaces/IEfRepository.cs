using System.Collections.Generic;
using System.Threading.Tasks;
using AdAstra.HRPlatform.Entities;

namespace AdAstra.HRPlatform.Services.Interfaces
{
    public interface IEfRepository<T> where T : BaseEntity
    {
        List<T> GetAll();
        T GetById(long id);
        Task<long> Add(T entity);

        Task Update(T entity);
        // TODO: expand if needed
    }
}