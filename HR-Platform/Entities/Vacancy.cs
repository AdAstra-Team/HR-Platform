namespace AdAstra.HRPlatform.API.Entities
{
    public class Vacancy : BaseEntity
    {
        public string Description { get; set; }
        public int Expirience { get; set; }
        public IEnumerable<SkillTag>? Skills { get; set; }
        public IEnumerable<ScheduleTag>? ScheduleTags { get; set; }
    }
}