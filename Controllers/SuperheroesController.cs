using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Super_Hero.Data;
using Super_Hero.Data.Migrations;
using Super_Hero.Models;


namespace Super_Hero.Controllers
{
    public class SuperheroesController : Controller
    {
        private readonly ApplicationDbContext _context;
        public SuperheroesController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: Superhero
        public ActionResult Index()
        {
            return View(_context.SuperHeroes.ToList());
        }

        // GET: Superhero/Details/5
        public ActionResult Details(int ID)
        {
            Hero heroDetails = _context.SuperHeroes.Where(s => s.ID == ID).FirstOrDefault();
            return View(heroDetails);
        }

        // GET: Superhero/Create
        public ActionResult Create()
        {
            Hero hero = new Hero();
            return View(hero);
        }

        // POST: Superhero/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Hero hero)
        {
            if(ModelState.IsValid)
            {
                // TODO: Add insert logic here
                _context.SuperHeroes.Add(hero);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            {
                return View(hero);
            }
        }

        // GET: Superhero/Edit/5
        public ActionResult Edit(int ID)
        {
            Hero hero = _context.SuperHeroes.Find(ID);
            return View(hero);
        }

        // POST: Superhero/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Hero Hero)
        {
            if (ModelState.IsValid)
            {
                // TODO: Add update logic here
                Hero oldHero = _context.SuperHeroes.Find(Hero.ID);
                oldHero.Name = Hero.Name;
                oldHero.AlterEgoName = Hero.AlterEgoName;
                oldHero.PrimaryPower = Hero.PrimaryPower;
                oldHero.SecondaryPower = Hero.SecondaryPower;
                oldHero.CatchPhrase= Hero.CatchPhrase;

                return RedirectToAction(nameof(Index));
            }
            {
                return View();
            }
        }

        // GET: Superhero/Delete/5
        public ActionResult Delete()
        {
            Hero hero = new Hero();
            return View(hero);
        }

        // POST: Superhero/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Hero hero)
        {
            try
            {
                // TODO: Add delete logic here
                _context.SuperHeroes.Remove(hero);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View();
            }
        }
    }
}