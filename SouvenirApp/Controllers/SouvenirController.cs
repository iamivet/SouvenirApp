using SouvenirApp.Data;
using SouvenirApp.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace SouvenirApp.Controllers
{
    public class SouvenirController
    {
        private SouvenirAppContext dbContext = new SouvenirAppContext();

        public List<Souvenir> GetAllSOuvenirs()
           => dbContext.Souvenirs.Include("SouvenirTypes").ToList();

        public void Create(Souvenir souvenir)
        {
            dbContext.Souvenirs.Add(souvenir);
            dbContext.SaveChanges();

        }

    
    }
}
