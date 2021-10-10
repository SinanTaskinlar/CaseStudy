using CaseStudyUrlShortener.Helpers;
using CaseStudyUrlShortener.Models;
using CaseStudyUrlShortener.Repositories.Base;
using CaseStudyUrlShortener.Repositories.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Threading.Tasks;

namespace CaseStudyUrlShortener.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class UrlController : ControllerBase
	{
		private readonly IAddressRepository _addressRepository;
		private Address _address;

		public UrlController(IAddressRepository addressRepository)
		{
			_addressRepository = addressRepository;
}
		[HttpGet]
		public IEnumerable<Address> Get()
		{
			return _addressRepository.GetAll().ToArray();
		}

		[HttpPost("Generate")]
		public JsonResult Generate(Address address)
		{
			using var helper = new UrlShortenerHelpers();
			if (helper.Validator(address.Long))
			{
				try
				{
					_address = _addressRepository.GetByOriginalUrl(address.Long);
					if (_address == null)
					{
						throw new Exception("No record");
					}
					else
					{
						return new JsonResult(_address.Short);
					}
				}
				catch
				{
					string shortUrl = _addressRepository.Save(helper.Shortener(address));
					return new JsonResult(shortUrl);
				}
			}
			else
			{
				return new JsonResult("Invalid Url");
			}
		}

		[HttpPost("Dispatch")]
		public JsonResult Dispatch(Address address)
		{
			try
			{
				using var helper = new UrlShortenerHelpers();
				if (helper.Validator(address.Short))
				{
					var _address = _addressRepository.GetByShortUrl(address.Short);
					return new JsonResult(_address.Long);
				}
				else
				{
					throw new Exception("Invalid Url");
				}
			}
			catch (Exception ex)
			{
				return new JsonResult(ex.Message);
				throw;
			}
		}
	}
}
