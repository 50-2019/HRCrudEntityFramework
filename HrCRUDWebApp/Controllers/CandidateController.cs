using HrCRUDWebApp.Data;
using HrCRUDWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
            _db.Candidates.Add(candidateObj);
            _db.SaveChanges();
            return RedirectToAction("Index");
		}   
	}
}
