using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CaseStudyUrlShortener.Models
{
	public class Address
	{
		private readonly Random _random = new Random();

		[Key]
		public int Id { get; set; }
		public string Short { get; set; }
		public string Long { get; set; }

		public Address()
		{
			Id = _random.Next(100000, 899999);
		}
	}
}
