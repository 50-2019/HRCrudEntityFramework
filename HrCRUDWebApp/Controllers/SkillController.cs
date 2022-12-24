using HrCRUDWebApp.Data;
using HrCRUDWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace HrCRUDWebApp.Controllers
{
	public class SkillController : Controller
	{
		private readonly ApplicationDbContext _db;
		public SkillController(ApplicationDbContext db)
		{
			_db = db;
		}

		public IActionResult Index()
		{
			IEnumerable<Skill> objList = _db.Skills;
			return View(objList);
		}
		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Create(Skill skillObj)
		{
			_db.Skills.Add(skillObj);
			_db.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}
