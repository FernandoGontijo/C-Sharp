using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SadaAPI.DTO
{
    public class ComunicacaoDTO
    {
        public int Id_Comunicacao { get; set; }
        public string Comentario { get; set; }
        public int Fk_Comunicacao { get; set; }
        public int Fk_Anuncio { get; set; }
        public System.DateTime DataHora { get; set; }
    }
}