namespace SouvenirApp.Data
{
    using SouvenirApp.Data.Models;
    using System.Data.Entity;

    public class SouvenirAppContext : DbContext
    {
        public SouvenirAppContext() : base("Shoesmag")
        {

        }

        public DbSet<Souvenir> Souvenirs { get; set; }
        public DbSet<SouvenirType> SouvenirTypes { get; set; }

    }
}
