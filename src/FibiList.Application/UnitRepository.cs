using FibiList.Domain.Entities;
using FibiList.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FibiList.Application
{
	public class UnitRepository
	{
		private readonly GroceriesContext _context;

		public UnitRepository(GroceriesContext context)
		{
			_context = context;
		}

		public List<Unit> GetUnits()
		{
			return _context.Units.ToList();
		}
	}
}
