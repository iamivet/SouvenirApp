using SouvenirApp.Data.Models;
using System.Data.Entity;

namespace SouvenirApp.Data
{
    public class SouvenirAppContext : DbContext
    {
        public SouvenirAppContext() : base("Shoesmag")
        {

        }

        public DbSet<Souvenir> Souvenirs { get; set; }
        public DbSet<SouvenirType> SouvenirTypes { get; set; }

    }
}
