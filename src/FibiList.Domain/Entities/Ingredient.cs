using FibiList.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace FibiList.Domain.Entities
{
	public class Ingredient : AuditableEntity
	{
		public Ingredient()
		{
			MealIngredients = new List<MealIngredient>();
		}

		public Guid Id { get; set; }
		public string Name { get; set; }
		public int? UnitId { get; set; }
		public Unit Unit { get; set; }
		public int? SectionId { get; set; }
		public Section Section { get; set; }

		public ICollection<MealIngredient> MealIngredients { get; set; }
	}
}
