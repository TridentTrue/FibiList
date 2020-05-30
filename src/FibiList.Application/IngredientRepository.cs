using FibiList.Application.Exceptions;
using FibiList.Application.Interfaces;
using FibiList.Domain.Entities;
using FibiList.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FibiList.Application
{
	public class IngredientRepository : IIngredientRepository
	{
		private readonly GroceriesContext _context;

		public IngredientRepository(GroceriesContext context)
		{
			this._context = context;
		}

		public async Task<IEnumerable<Ingredient>> GetAll()
		{
			return await _context.Ingredients.OrderBy(i => i.Name).ToListAsync();
		}

		public async Task<Ingredient> Get(Guid id)
		{
			return await _context.Ingredients.FindAsync(id);
		}

		public async Task<Ingredient> Create(Ingredient newIngredient)
		{
			_context.Ingredients.Add(newIngredient);
			await _context.SaveChangesAsync();
			return newIngredient;
		}

		public async Task<Ingredient> Update(Ingredient updatedIngredient)
		{
			Ingredient ingredientInDb = await _context.Ingredients.FindAsync(updatedIngredient.Id);

			if (ingredientInDb == null)
			{
				throw new NotFoundException(nameof(Ingredient), updatedIngredient.Id);
			}

			ingredientInDb.Name = updatedIngredient.Name;
			ingredientInDb.UnitId = updatedIngredient.UnitId;
			ingredientInDb.SectionId = updatedIngredient.SectionId;

			await _context.SaveChangesAsync();
			return ingredientInDb;
		}

		public async Task<Ingredient> Delete(Guid id)
		{
			Ingredient ingredientToDelete = await _context.Ingredients.FindAsync(id);

			if (ingredientToDelete == null)
			{
				throw new NotFoundException(nameof(Ingredient), id);
			}

			_context.Ingredients.Remove(ingredientToDelete);
            await _context.SaveChangesAsync();
			return ingredientToDelete;
		}

		public bool Exists(Guid id)
		{
			return _context.Ingredients.Any(e => e.Id == id);
		}
	}
}