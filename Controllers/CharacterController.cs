using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;//Allows to use lambda expressions, which we will use in our CRUD methods

using MoreAsp.Models;

namespace MoreAsp.Controllers
{
    public class CharacterController : Controller
    {
        // when a variable is private readonly the convection to name is
        //underscore and lower case.
        //what it is?
        private readonly ApplicationDbContext _context;

        //Character controller contructor
        public CharacterController(ApplicationDbContext context)
        {
            // constructor injection, which allows us to inject (a instant) ApplictationDbContext into our controller
            //what it is?
            _context = context;
        }

        public IActionResult Create(Character character)
        {
            _context.Characters.Add(character);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        //this will be our "Read all" characters functionality
        public IActionResult Index()
        {
            throw new System.ArgumentException("Pase por Index, antes de mandar la lista");
            //ToList() converts a collection into a List collection. 

            if (_context.Characters.ToList() != null)//Me tira error!!!
            {
                var model = _context.Characters.ToList();

                return View(model);
            }
            else
            {
                throw new System.ArgumentException("la lista esta vacia. Macana!");
            }

        }

        public IActionResult GetActive()
        {
            var model = _context.Characters.Where(e => e.IsActive).ToList();

            return View(model);
        }

        public IActionResult Details(string name)
        {
            var model = _context.Characters.FirstOrDefault(e => e.Name == name);

            return View(model);
        }

        public IActionResult Update(Character character)
        {
            //To update a record we can use Entry to locate and set our data, then set its
            //State to Modified. This lets EntityFramework know we have changed the record.
            _context.Entry(character).State = EntityState.Modified;
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(string name)
        {
            var original = _context.Characters.FirstOrDefault(e => e.Name == name);
            if (original != null)
            {
                _context.Characters.Remove(original);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}   