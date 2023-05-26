using System.ComponentModel.DataAnnotations;
using AdAstra.HRPlatform.API.Entities.Base;

namespace AdAstra.HRPlatform.API.Entities
{
    public class CandidateInfo : BaseEntity
    {
        public Vacancy Vacancy { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string? Phone { get; set; }
        public string? Telegram { get; set; }
        public int Expirience { get; set; }
        public ICollection<SkillTag>? Skills { get; set; }
        public ICollection<ScheduleTag>? ScheduleTags { get; set; }
    }
}
