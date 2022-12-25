using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HrCRUDWebApp.Models
{
    public class Candidate
    {
        public int Id { get; set; }
        [DisplayName("Candidate full name")]
		[Required]
		public string FullName { get; set; }
		[DisplayName("Candidate date of birth")]
		public DateTime DateOfBirth { get; set; }
		[DisplayName("Candidate phone number")]
		public string ContactNumber { get; set; }
		[DisplayName("Candidate email")]
		public string Email { get; set; }
		public virtual ICollection<CandidateSkill> CandidateSkill { get; set; }
    }
}
