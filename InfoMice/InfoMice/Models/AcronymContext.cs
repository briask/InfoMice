namespace InfoMice.Models
{
    using System.Data.Entity;

    public class AcronymContext : DbContext
    {
        public DbSet<Acronym> Acronyms { get; set; }
    }
}
