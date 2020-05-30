using FibiList.Application.Interfaces;
using FibiList.Domain.Entities;
using FibiList.Infrastructure.Persistence;
using FibiList.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace FibiList.MVC.Controllers
{
    public class IngredientsController : Controller
    {
        private readonly GroceriesContext _context;
        private readonly IIngredientRepository _ingredientRepo;

        public IngredientsController(GroceriesContext context, IIngredientRepository ingredientRepo)
        {
            _context = context;
            _ingredientRepo = ingredientRepo;
        }

        // GET: Ingredients
        public async Task<IActionResult> Index()
        {
            return View(await _ingredientRepo.GetAll());
        }

        // GET: Ingredients/Details/id
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Ingredient ingredient = await _ingredientRepo.Get((Guid)id);
            if (ingredient == null)
            {
                return NotFound();
            }

            return View(ingredient);
        }

        // GET: Ingredients/Create
        public IActionResult Create()
        {
            return View("IngredientForm", new IngredientFormViewModel(_context));
        }

        // GET: Ingredients/Edit/id
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Ingredient ingredient = await _ingredientRepo.Get((Guid)id);
            if (ingredient == null)
            {
                return NotFound();
            }

            return View("IngredientForm", new IngredientFormViewModel(_context, ingredient));
        }

        // POST: Ingredients/Save
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(IngredientFormViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("IngredientForm", vm);
            }

            Ingredient ingredient = vm.ToIngredient();

            if (vm.Id == null)
            {
                // add
                await _ingredientRepo.Create(ingredient);
            }
            else
            {
                // edit
                try
                {
                    await _ingredientRepo.Update(ingredient);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_ingredientRepo.Exists(ingredient.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: Ingredients/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Ingredient ingredient = await _ingredientRepo.Get((Guid)id);
            if (ingredient == null)
            {
                return NotFound();
            }

            return View(ingredient);
        }

        // POST: Ingredients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            Ingredient ingredient = await _ingredientRepo.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
