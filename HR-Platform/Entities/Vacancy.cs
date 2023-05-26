using AdAstra.HRPlatform.API.Entities.Base;
using AdAstra.HRPlatform.API.Entities.Roles;

namespace AdAstra.HRPlatform.API.Entities
{
    public class Vacancy : BaseEntity
    {
        public HRManagerRole HRManager { get; set; }
        public EmployerRole Employer { get; set; }
        public string Description { get; set; }
        public int Expirience { get; set; }
        public ICollection<SkillTag>? Skills { get; set; }
        public ICollection<ScheduleTag>? ScheduleTags { get; set; }
    }
}