using SadaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SadaAPI.Repository
{
    public class AnuncioRepository : BaseRepository
    {
        public Anuncio GetOne(int id)
        {
            return DataModel.Anuncio.FirstOrDefault(e => e.Id_Anuncio == id);
        }

        public List <Anuncio> GetAll()
        {
            return DataModel.Anuncio.ToList();
        }

        public void Delete(int id)
        {
            var anuncio = GetOne(id);
            DataModel.Anuncio.Remove(anuncio);

            DataModel.SaveChanges();

        }

        public void Save(Anuncio entity)
        {
            DataModel.Entry(entity).State = entity.Id_Anuncio == 0 ?
                System.Data.Entity.EntityState.Added : System.Data.Entity.EntityState.Modified;

            DataModel.SaveChanges();
        }



    }
}