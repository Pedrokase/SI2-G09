using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI2_G09.model
{
    public class AutorArtigo
    {
		public virtual Utilizador Utilizador { get; set; }
		public virtual Artigo ArtigoDoAutor { get; set; }
		public int? Nota { get; set; }
		public string Texto { get; set; }
    }
}
