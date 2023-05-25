using System.Collections.Generic;
using System.Threading.Tasks;
using AdAstra.HRPlatform.API.Entities;

namespace AdAstra.HRPlatform.API.Services.Interfaces
{
    public interface IEfRepository<T> where T : BaseEntity
    {
        List<T> GetAll();
        T GetById(long id);
        Task<long> Add(T entity);

        void Update(T entity);
        // TODO: expand if needed
    }
}