namespace SouvenirApp.Controllers
{
    using SouvenirApp.Data;
    using System.Collections.Generic;
    using System.Linq;

    public class SouvenirController
    {
        private SouvenirAppContext dbContext = new SouvenirAppContext();

        public List<Souvenir> GetAllSоuvenirs()
           => dbContext.Souvenirs
            .Include("Type")
            .ToList();

        public void Create(Souvenir souvenir)
        {
            dbContext.Souvenirs.Add(souvenir);
            dbContext.SaveChanges();

        }

        public Souvenir GetById(int id)
        {
            Souvenir findedSouvenir = dbContext.Souvenirs.Find(id);

            if (findedSouvenir != null)
            {
                dbContext.Entry(findedSouvenir).Reference(s => s.Type).Load();
            }

            return findedSouvenir;
        }


        public void Update(int id, Souvenir souvenir)
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
        public void Delete(int id)
        {
            Souvenir findedSouvenir = dbContext.Souvenirs.Find(id);
            dbContext.Souvenirs.Remove(findedSouvenir);
            dbContext.SaveChanges();
        }
    }
}
