using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using AdAstra.HRPlatform.API.Entities.Base;

namespace AdAstra.HRPlatform.API.Entities
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Index(IsUnique = true)]
        public string Username { get; set; }
        [EmailAddress]
        [Index(IsUnique = true)]
        public string Email { get; set; }
        [JsonIgnore]
        public string Password { get; set; }

        [JsonIgnore]
        public string? RefreshToken { get; set; }
        [JsonIgnore]
        public DateTime? RefreshTokenExpiryTime { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
    }
}