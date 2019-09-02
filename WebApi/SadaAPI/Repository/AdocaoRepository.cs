using SadaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SadaAPI.Repository
{
    public class AdocaoRepository : BaseRepository
    {

        public Adocao GetOne (int id) {

            return DataModel.Adocao.FirstOrDefault(e => e.Id_Adocao == id);

            }

        public List <Adocao> GetAll()
        {
            return DataModel.Adocao.ToList();
        }

        public void Delete(int id)
        {
            var adocao = GetOne(id);
            DataModel.Adocao.Remove(adocao);
            DataModel.SaveChanges();
        }

        public void Save(Adocao entity)
        {
            DataModel.Entry(entity).State = entity.Id_Adocao == 0 ?
                System.Data.Entity.EntityState.Added : System.Data.Entity.EntityState.Modified;

            DataModel.SaveChanges();
        }



    }
}