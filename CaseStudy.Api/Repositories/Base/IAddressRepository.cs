using CaseStudyUrlShortener.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseStudyUrlShortener.Repositories.Base
{
	public interface IAddressRepository
	{
		IQueryable<Address> GetAll();
		Address GetByShortUrl(string path);
		Address GetByOriginalUrl(string originalUrl);
		string Save(Address address);
	}
}
