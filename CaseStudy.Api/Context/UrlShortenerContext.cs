using CaseStudyUrlShortener.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace CaseStudyUrlShortener.Context
{
    public class UrlShortenerContext : DbContext
    {
        public UrlShortenerContext(DbContextOptions options)
        : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(
                @"User ID =postgres;Password=1234;Server=localhost;Port=5432;Database=testDb;Integrated Security=true;Pooling=true;");
}

        public DbSet<Address> Addresses { get; set; }
    }
}
