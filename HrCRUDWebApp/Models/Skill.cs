using System.Collections.Generic;
using System.ComponentModel;

namespace HrCRUDWebApp.Models
{
    public class Skill
    {
        public int Id { get; set; }
        [DisplayName("Skill name")]
        public string Name { get; set; }
		public virtual ICollection<CandidateSkill> CandidateSkill { get; set; }
	}
}
