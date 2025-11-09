using GeographyAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GeographyAPI.Data
{
    public class GeographyContext : DbContext
    {
        public GeographyContext(DbContextOptions<GeographyContext> options) : base(options)
        {

        }

        public DbSet<Language> Language { get; set; }
        public DbSet<Country> Country { get; set; }

        public DbSet<CountryLanguage> CountryLanguage { get; set; }

    }
}
