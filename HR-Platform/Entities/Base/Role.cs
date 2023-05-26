using System.ComponentModel.DataAnnotations;

namespace AdAstra.HRPlatform.API.Entities.Base
{
    public abstract class Role : BaseEntity
    {
        [Required]
        public string Name { get; set; }
    }
}
