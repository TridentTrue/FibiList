using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FibiList.Domain.Entities;
using FibiList.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace FibiList.MVC.Controllers
{
    public class TestController : Controller
    {
        private readonly GroceriesContext _context;

        public TestController(GroceriesContext context)
        {
            _context = context;
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
                });
                listOfAllIngredients.Add(new Ingredient()
                {
                    Id = new Guid(),
                    Name = "Milk",
                });
                listOfAllIngredients.Add(new Ingredient()
                {
                    Id = new Guid(),
                    Name = "Cheese",
                });
                listOfAllIngredients.Add(new Ingredient()
                {
                    Id = new Guid(),
                    Name = "Bread",
                });

                _context.Ingredients.AddRange(listOfAllIngredients);
                _context.SaveChangesAsync();
            }

            return View(listOfAllIngredients);
        }
    }
}