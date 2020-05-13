using FibiList.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace FibiList.Domain.Entities
{
	public class Meal : AuditableEntity
	{
		public Meal()
		{
			Ingredients = new List<MealIngredient>();
		}

		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string ImageUrl { get; set; }
		public Guid MealPlanId { get; set; }
		public MealPlan MealPlan { get; set; }

		public ICollection<MealIngredient> Ingredients { get; set; }
	}
}
