using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SadaAPI.DTO
{
    public class AdocaoDTO
    {
        public int Id_Adocao { get; set; }
        public System.DateTime DataAdocao { get; set; }
        public int Fk_Usuario { get; set; }
        public int Fk_Anuncio { get; set; }
    }
}