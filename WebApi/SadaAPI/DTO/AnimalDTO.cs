using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SadaAPI.DTO
{
    public class AnimalDTO
    {
        public int Id_Animal { get; set; }
        public string Nome { get; set; }
        public string Raca { get; set; }
        public string Sexo { get; set; }
        public string Tamanho { get; set; }
        public string Cor { get; set; }
        public string DescricaoAnimal { get; set; }
    }
}