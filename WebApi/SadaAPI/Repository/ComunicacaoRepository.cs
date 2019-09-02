using SadaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SadaAPI.Repository
{
    public class ComunicacaoRepository : BaseRepository
    {
        public Comunicacao GetOne (int id)
        {
            return DataModel.Comunicacao.FirstOrDefault(e => e.Id_Comunicacao == id);
        }

        public List <Comunicacao> GetAll()
        {
            return DataModel.Comunicacao.ToList();
        }

        public void Delete(int id)
        {
            var comunicacao = GetOne(id);
            DataModel.Comunicacao.Remove(comunicacao);

            DataModel.SaveChanges();
        }
        
        public void Save(Comunicacao entity)
        {
            DataModel.Entry(entity).State = entity.Id_Comunicacao == 0 ?
                System.Data.Entity.EntityState.Added : System.Data.Entity.EntityState.Modified;

            DataModel.SaveChanges();

        }
    }
}