using System;
using System.Collections.Generic;
using System.Text;

namespace FibiList.Domain.Entities
{
	public class Unit
	{
		public int Id { get; set; }
		public string ShortDescriptor { get; set; }
		public string SingularDescriptor { get; set; }
		public string PluralDescriptor { get; set; }
	}
}
