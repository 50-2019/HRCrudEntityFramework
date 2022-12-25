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
			if (ModelState.IsValid)
			{
				_db.Skills.Add(skillObj);
				_db.SaveChanges();
				return RedirectToAction("Index");
			}
			else
			{
				return View();
			}
		}
		public IActionResult Delete(int? Id)
		{
			var obj = _db.Skills.Find(Id);
			if (obj == null)
				return NotFound();

			_db.Skills.Remove(obj);
			_db.SaveChanges();
			return RedirectToAction("Index");
		}
		public IActionResult Update(int? Id)
		{
			if (Id == null)
			{
				return NotFound();
			}
			var obj = _db.Skills.Find(Id);
			if (obj == null)
			{
				return NotFound();
			}
			return View(obj);
		}
		[HttpPost]
		public IActionResult Update(Skill skillObj)
		{
			if (ModelState.IsValid)
			{
				_db.Skills.Update(skillObj);
				_db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View();
		}
	}
}
