using CaseStudyUrlShortener.Context;
using CaseStudyUrlShortener.Models;
using CaseStudyUrlShortener.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseStudyUrlShortener.Repositories.Concrete
{
    public class AddressRepository : IAddressRepository
    {
        private readonly UrlShortenerContext _context;

        public AddressRepository(UrlShortenerContext context)
        {
            _context = context;
        }

        public IQueryable<Address> GetAll()
        {
            return _context.Addresses.AsQueryable(); ;
        }

        public Address GetByShortUrl(string shortUrl)
        {
            foreach (var address in _context.Addresses)
            {
                if (address.Short == shortUrl)
                {
                    return address;
                }
            }
            return null;
        }

        public Address GetByOriginalUrl(string originalUrl)
        {
            foreach (var address in _context.Addresses)
            {
                if (address.Long == originalUrl)
                {
                    return address;
                }
            }
            return null;
        }

        public string Save(Address address)
        {
            _context.Addresses.Add(address);
            _context.SaveChanges();

            return address.Short;
        }
    }
}
