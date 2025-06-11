using SouvenirApp.Data;
using System.Collections.Generic;
using System.Linq;

namespace SouvenirApp.Controllers
{
    public class SouvenirTypeController
    {
        private SouvenirAppContext dbContext = new SouvenirAppContext();

        public List<SouvenirType> GetAllSоuvenirTypes()
           => dbContext.SouvenirTypes.ToList();

        public void Create(SouvenirType type)
        {
            dbContext.SouvenirTypes.Add(type);
            dbContext.SaveChanges();

        }

        public SouvenirType GetById(int id)
        {
            SouvenirType findedSouvenirType = dbContext.SouvenirTypes.Find(id);

            if (findedSouvenirType != null)
            {
                dbContext.Entry(findedSouvenirType);
            }

            return findedSouvenirType;
        }
    }
}
