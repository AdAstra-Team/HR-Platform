using AdAstra.HRPlatform.API.Entities.Base;
using AdAstra.HRPlatform.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AdAstra.HRPlatform.API.Helpers
{
    public static class ValidationHelper
    {
        public static bool ValidateUnique<T, T1>(T obj, IEfRepository<T> repo, Func<T, T1> func) where T : BaseEntity
        {
            if (obj == null)
            {
                return false;
            }
            return !repo.GetAll().Any(e => 
                func(obj).Equals(func(e)));
        }
    }
}
