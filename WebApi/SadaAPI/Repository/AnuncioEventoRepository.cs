using SadaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SadaAPI.Repository
{
    public class AnuncioEventoRepository : BaseRepository
    {
        public AnuncioEvento GetOne(int id)
        {
            return DataModel.AnuncioEvento.FirstOrDefault(e => e.Id_AnuncioEvento == id);

        }

        public List <AnuncioEvento> GetAll()
        {
            return DataModel.AnuncioEvento.ToList();
        }

        public void Delete(int id)
        {
            var anuncioEvento = GetOne(id);
            DataModel.AnuncioEvento.Remove(anuncioEvento);

            DataModel.SaveChanges();
        }

        public void Save(AnuncioEvento entity)
        {
            DataModel.Entry(entity).State = entity.Id_AnuncioEvento == 0 ?
                System.Data.Entity.EntityState.Added : System.Data.Entity.EntityState.Modified;

            DataModel.SaveChanges();
        }


    }
}