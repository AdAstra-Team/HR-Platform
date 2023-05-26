using System.Collections.Generic;
using System.Threading.Tasks;
using AdAstra.HRPlatform.API.Entities.Base;

namespace AdAstra.HRPlatform.API.Services.Interfaces
{
    public interface IEfRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        T GetById(long id);
        long Add(T entity);

        void Update(T entity);
        // TODO: expand if needed
    }
}