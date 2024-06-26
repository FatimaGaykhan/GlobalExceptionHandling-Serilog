using System;
using Domain.Common;

namespace Domain.Entities
{
	public class Country:BaseEntity
	{
		public string Name { get; set; }

		public IEnumerable<Country> Countries { get; set; }

	}
}

