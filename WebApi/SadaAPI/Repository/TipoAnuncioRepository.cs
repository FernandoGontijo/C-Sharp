using SadaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SadaAPI.Repository
{
    public class TipoAnuncioRepository : BaseRepository
    {

        public TipoAnuncio GetOne(int id)
        {
            return DataModel.TipoAnuncio.FirstOrDefault(e => e.Id_TipoAnuncio == id);
        }

        public List<TipoAnuncio> GetAll()
        {
            return DataModel.TipoAnuncio.ToList();
        }

        public void Delete(int id)
        {
            var tipoAnuncio = GetOne(id);
            DataModel.TipoAnuncio.Remove(tipoAnuncio);

            DataModel.SaveChanges();

        }

        public void Save(TipoAnuncio entity)
        {
            DataModel.Entry(entity).State = entity.Id_TipoAnuncio == 0 ?
                System.Data.Entity.EntityState.Added : System.Data.Entity.EntityState.Modified;

            DataModel.SaveChanges();
        }

    }
}