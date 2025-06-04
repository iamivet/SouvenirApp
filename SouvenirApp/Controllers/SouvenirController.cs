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

      public Souvenir Get(int Id)
        {
            Souvenir findedSouvenir = dbContext.Souvenirs.Find(Id);

            if(findedSouvenir != null)
            {
               dbContext.Entry(findedSouvenir).Reference(s => s.Type).Load();  
            }

           return findedSouvenir;
        }


        public void Update(int id,Souvenir souvenir)
        {
            Souvenir findedSouvenir = dbContext.Souvenirs.Find(id);

            if (findedSouvenir == null)
                return;

            findedSouvenir.Name = souvenir.Name;
            findedSouvenir.Description = souvenir.Description;
            findedSouvenir.Price = souvenir.Price;
            findedSouvenir.TypeId = souvenir.TypeId;


            dbContext.SaveChanges();

        }
    
    }
}
