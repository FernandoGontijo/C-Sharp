using SadaAPI.DTO;
using SadaAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SadaAPI.Repository
{
    public class AnimalRepository : BaseRepository
    {
        public Animal GetOne(int id)
        {
            return DataModel.Animal.FirstOrDefault(e => e.Id_Animal == id);
        }

        public List <Animal> GetAll()
        {
            return DataModel.Animal.ToList();
        }

        public void Delete(int id)
        {
            var animal = GetOne(id);
            DataModel.Animal.Remove(animal);

            DataModel.SaveChanges();
        }

        public void Save(AnimalDTO entity) // Editar dados no banco
        {

            Animal animal = new Animal
            {
                Nome = entity.Nome,
                Id_Animal = entity.Id_Animal,
                Raca = entity.Raca,
                Sexo = entity.Sexo,
                Tamanho = entity.Tamanho,
                Cor = entity.Cor,
                DescricaoAnimal = entity.DescricaoAnimal
            };

            DataModel.Entry(animal).State = entity.Id_Animal == 0 ?
                EntityState.Added : EntityState.Modified; // vai buscar o usuário pelo id (caso ele exista) e modificar

            DataModel.SaveChanges();

        }


    }
}