//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EFSI2_G09
{
    using System;
    using System.Collections.Generic;
    
    public partial class Utilizador
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Utilizador()
        {
            this.Autor_Artigo = new HashSet<Autor_Artigo>();
            this.Conferencia = new HashSet<Conferencia>();
            this.Revisor_Artigo = new HashSet<Revisor_Artigo>();
            this.Instituicao = new HashSet<Instituicao>();
        }
    
        public int ID { get; set; }
        public string email { get; set; }
        public string nome { get; set; }
    
        public virtual Autor Autor { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Autor_Artigo> Autor_Artigo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Conferencia> Conferencia { get; set; }
        public virtual Conferencia_Utilizador Conferencia_Utilizador { get; set; }
        public virtual Revisor Revisor { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Revisor_Artigo> Revisor_Artigo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Instituicao> Instituicao { get; set; }
    }
}
