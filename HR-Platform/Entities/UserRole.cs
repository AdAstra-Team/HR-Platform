using System.ComponentModel.DataAnnotations;
using AdAstra.HRPlatform.API.Entities.Base;

namespace AdAstra.HRPlatform.API.Entities
{
    public class UserRole : BaseEntity
    {
        public long UserId { get; set; }
        public User User { get; set; }
        public long RoleId { get; set; }
        public Role Role { get; set; }
    }

}
