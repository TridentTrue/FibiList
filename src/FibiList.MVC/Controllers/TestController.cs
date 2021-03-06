﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FibiList.Domain.Entities;
using FibiList.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using FibiList.Domain.Enums;

namespace FibiList.MVC.Controllers
{
    public class TestController : Controller
    {
        private readonly GroceriesContext _context;

        public TestController(GroceriesContext context)
        {
            _context = context;
        }

        public JsonResult GetUnit()
        {
            return Json(_context.Units.Find((int)Units.litre));
        }

        public IActionResult Index()
        {
            List<Ingredient> listOfAllIngredients = _context.Ingredients.ToList();

            if (listOfAllIngredients.Count == 0)
            {
                // populate db and re-do
                listOfAllIngredients.Add(new Ingredient()
                {
                    Id = new Guid(),
                    Name = "Cucumber",
                    UnitId = null,
                    SectionId = (int)Sections.FruitAndVegetables,
                });
                listOfAllIngredients.Add(new Ingredient()
                {
                    Id = new Guid(),
                    Name = "Milk",
                    UnitId = (int)Units.litre,
                    SectionId = (int)Sections.DairyEggsAndChilled,
                });
                listOfAllIngredients.Add(new Ingredient()
                {
                    Id = new Guid(),
                    Name = "Cheese",
                    UnitId = (int)Units.gram,
                    SectionId = (int)Sections.DairyEggsAndChilled,
                });
                listOfAllIngredients.Add(new Ingredient()
                {
                    Id = new Guid(),
                    Name = "Bread",
                    UnitId = null,
                    SectionId = (int)Sections.Bakery,
                });

                _context.Ingredients.AddRange(listOfAllIngredients);
                _context.SaveChangesAsync();
            }

            return View(listOfAllIngredients);
        }
    }
}