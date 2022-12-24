using HrCRUDWebApp.Data;
using HrCRUDWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace HrCRUDWebApp.Controllers
{
	public class CandidateSkillController : Controller
	{
		private readonly ApplicationDbContext _db;
		public CandidateSkillController(ApplicationDbContext db)
		{
			_db = db;
		}

		public IActionResult Index()
		{
			IEnumerable<CandidateSkill> objList = _db.CandidatesSkill;
			return View(objList);
		}
		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Create(CandidateSkill candidateSkillObj)
		{
			bool bool1 , bool2;
			bool1 = bool2 = false;
			Candidate[] array1 = _db.Candidates.ToArray();
			Skill[] array2 = _db.Skills.ToArray();
			int lengthOfList = array1.Length > array2.Length ? array1.Length : array2.Length;
			for (int i = 0; i<lengthOfList;i++)
			{
				if (array1[i% array1.Length].Id==candidateSkillObj.CandidateId) 
					bool1 = true;
				if(array2[i % array2.Length].Id == candidateSkillObj.SkillId)
					bool2 = true;
			}
			if (bool1 && bool2) { 
			_db.CandidatesSkill.Add(candidateSkillObj);
			_db.SaveChanges();
			return RedirectToAction("Index");
			}
			else
			{ return RedirectToAction("Error"); }
		}
		public IActionResult Error ()
		{
			return View();
		}
	}
}
