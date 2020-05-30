using FibiList.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FibiList.Application.Interfaces
{
	public interface IIngredientRepository
	{
		Task<IEnumerable<Ingredient>> GetAll();
		Task<Ingredient> Get(Guid id);
		Task<Ingredient> Create(Ingredient newIngredient);
		Task<Ingredient> Update(Ingredient updatedIngredient);
		Task<Ingredient> Delete(Guid id);
		bool Exists(Guid id);
	}
}
