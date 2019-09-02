using SadaAPI.DTO;
using SadaAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SadaAPI.Repository
{
    public class EventoRepository : BaseRepository
    {

        public Evento GetOne(int id)
        {

            return DataModel.Evento.FirstOrDefault(e => e.Id_Evento == id);

        }

        public List <Evento> GetAll()
        {
            return DataModel.Evento.ToList();
        }

        public void Delete(int id)
        {

            var evento = GetOne(id);
            DataModel.Evento.Remove(evento);

            DataModel.SaveChanges();
        }

        public void Save(EventoDTO entity) // Editar dados no banco
        {

            Evento evento = new Evento
            {
                Nome = entity.Nome,
                Id_Evento = entity.Id_Evento,
                DescricaoEvento = entity.DescricaoEvento,
                DataInicio = entity.DataInicio,
                DataEncerramento = entity.DataEncerramento,
                Local = entity.Local,
                ListaDePresenca = entity.ListaDePresenca,
                Fk_Usuario = entity.Fk_Usuario
            };

            DataModel.Entry(evento).State = entity.Id_Evento == 0 ?
                EntityState.Added : EntityState.Modified; // vai buscar o usuário pelo id (caso ele exista) e modificar

            DataModel.SaveChanges();

        }






    }
}