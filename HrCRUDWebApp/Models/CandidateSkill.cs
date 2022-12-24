using System.ComponentModel.DataAnnotations;

namespace HrCRUDWebApp.Models
{
	public class CandidateSkill
	{
		[Required]
		[Range(0,int.MaxValue)]
		public int CandidateId { get; set; }
		public Candidate Candidate { get; set; }
		[Required]
		[Range(0, int.MaxValue)]
		public int SkillId { get; set;}
		public Skill Skill { get; set; }		
	}
}
