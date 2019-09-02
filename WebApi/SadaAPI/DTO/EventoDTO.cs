using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SadaAPI.DTO
{
    public class EventoDTO
    {
        public int Id_Evento { get; set; }
        public string Nome { get; set; }
        public string DescricaoEvento { get; set; }
        public System.DateTime DataInicio { get; set; }
        public System.DateTime DataEncerramento { get; set; }
        public string Local { get; set; }
        public string ListaDePresenca { get; set; }
        public int Fk_Usuario { get; set; }
    }
}