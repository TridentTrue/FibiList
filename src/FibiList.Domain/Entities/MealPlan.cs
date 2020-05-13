using FibiList.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace FibiList.Domain.Entities
{
	public class MealPlan : AuditableEntity
	{
		public MealPlan()
		{
			Meals = new List<Meal>();
		}

		public Guid Id { get; set; }
		public ICollection<Meal> Meals { get; set; }
	}
}
