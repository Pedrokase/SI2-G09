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
    
    public partial class FicheiroPDF
    {
        public int file_version { get; set; }
        public int ID { get; set; }
        public int conferenceID { get; set; }
    
        public virtual Artigo Artigo { get; set; }
    }
}
