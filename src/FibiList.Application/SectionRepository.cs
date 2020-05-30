using FibiList.Domain.Entities;
using FibiList.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FibiList.Application
{
	public class SectionRepository
	{
		private readonly GroceriesContext _context;

		public SectionRepository(GroceriesContext context)
		{
			_context = context;
		}

		public List<Section> GetSections()
		{
			return _context.Sections.ToList();
		}
	}
}
