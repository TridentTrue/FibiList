using FibiList.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace FibiList.Domain.Entities
{
	public class MealIngredient : AuditableEntity
	{
		public Guid MealId { get; set; }
		public Meal Meal { get; set; }

		public Guid IngredientId { get; set; }
		public Ingredient Ingredient { get; set; }

		public decimal Quantity { get; set; }
		public string Notes { get; set; }
	}
}
