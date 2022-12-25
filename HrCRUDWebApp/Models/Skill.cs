using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HrCRUDWebApp.Models
{
    public class Skill
    {
        public int Id { get; set; }
        [DisplayName("Skill name")]
		[Required]
		public string Name { get; set; }
		public virtual ICollection<CandidateSkill> CandidateSkill { get; set; }
	}
}
