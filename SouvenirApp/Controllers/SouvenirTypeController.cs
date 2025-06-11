using SouvenirApp.Data;
using System.Collections.Generic;
using System.Linq;

namespace SouvenirApp.Controllers
{
    public class SouvenirTypeController
    {
        private SouvenirAppContext dbContext = new SouvenirAppContext();

        public List<SouvenirType> GetAllSоuvenirs()
           => dbContext.SouvenirTypes.ToList();

        public void Create(SouvenirType type)
        {
            dbContext.SouvenirTypes.Add(type);
            dbContext.SaveChanges();

        }
    }
}
