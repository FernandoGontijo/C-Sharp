//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SadaAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Comunicacao
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Comunicacao()
        {
            this.Comunicacao1 = new HashSet<Comunicacao>();
        }
    
        public int Id_Comunicacao { get; set; }
        public string Comentario { get; set; }
        public System.DateTime DataHora { get; set; }
        public int Fk_Anuncio { get; set; }
        public Nullable<int> Fk_Comunicacao { get; set; }
    
        public virtual Anuncio Anuncio { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comunicacao> Comunicacao1 { get; set; }
        public virtual Comunicacao Comunicacao2 { get; set; }
    }
}
