using FibiList.Application;
using FibiList.Domain.Entities;
using FibiList.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.ComponentModel.DataAnnotations;

namespace FibiList.MVC.ViewModels
{
	public class IngredientFormViewModel
	{
		public Guid? Id { get; set; }

		[Display(Name = "Name of Ingredient")]
		public string Name { get; set; }

		[Display(Name = "Measured in...")]
		public int? UnitId { get; set; }
		public Unit Unit { get; set; }

		[Display(Name = "Section")]
		public int? SectionId { get; set; }
		public Section Section { get; set; }

		public SelectList UnitsSelectList{ get; private set; }
		public SelectList SectionsSelectList { get; private set; }

		public IngredientFormViewModel()
		{

		}

		public IngredientFormViewModel(GroceriesContext context)
		{
			UnitRepository unitRepo = new UnitRepository(context);
			UnitsSelectList = new SelectList(unitRepo.GetUnits(), "Id", "PluralDescriptor");

			SectionRepository sectionRepo = new SectionRepository(context);
			SectionsSelectList = new SelectList(sectionRepo.GetSections(), "Id", "Name");
		}

		public IngredientFormViewModel(GroceriesContext context, Ingredient ingredient)
		{
			Id = ingredient.Id;
			Name = ingredient.Name;
			UnitId = ingredient.UnitId;
			Unit = ingredient.Unit;
			SectionId = ingredient.SectionId;
			Section = ingredient.Section;

			UnitRepository unitQueries = new UnitRepository(context);
			UnitsSelectList = new SelectList(unitQueries.GetUnits(), "Id", "PluralDescriptor", UnitId);

			SectionRepository sectionQueries = new SectionRepository(context);
			SectionsSelectList = new SelectList(sectionQueries.GetSections(), "Id", "Name", SectionId);
		}

		public Ingredient ToIngredient()
		{
			return new Ingredient()
			{
				Id = Id ?? Guid.NewGuid(),
				Name = Name,
				UnitId = UnitId,
				SectionId = SectionId,
			};
		}
	}
}
