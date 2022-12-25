using HrCRUDWebApp.Data;
using HrCRUDWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text;

namespace HrCRUDWebApp.Controllers
{
    public class CandidateController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CandidateController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Candidate> objList = _db.Candidates;
            return View(objList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
		public IActionResult Create(Candidate candidateObj)
		{
            if(ModelState.IsValid) { 
                _db.Candidates.Add(candidateObj);
                _db.SaveChanges();
                return RedirectToAction("Index");
			}
            return View();
		}
		public IActionResult Delete(int? Id)
		{
            var obj = _db.Candidates.Find(Id);
            if(obj == null)
                return NotFound();
			
				_db.Candidates.Remove(obj);
				_db.SaveChanges();
				return RedirectToAction("Index");
		}
        public IActionResult Update(int? Id)
        {
            if(Id == null)
            {
                return NotFound();
            }
            var obj = _db.Candidates.Find(Id);
            if(obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        [HttpPost]
		public IActionResult Update(Candidate candidateObj)
		{
			if (ModelState.IsValid)
			{
				_db.Candidates.Update(candidateObj);        
				_db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View();
		}
        public IActionResult Show(int? Id)
        {
            LinkedList<Skill> list = new LinkedList<Skill>();
            foreach(CandidateSkill cs in _db.CandidatesSkill) { 
                if(cs.CandidateId == Id)
                {
                    list.AddLast((_db.Skills.Find(cs.SkillId))); 
                }
            }
			return View(list);
		}
    
	}
}
