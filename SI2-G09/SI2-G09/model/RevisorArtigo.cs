using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI2_G09.model
{
    public class RevisorArtigo
    {
        public virtual Revisor Revisor { get; set; }

        public virtual Artigo ArtigoRevisto { get; set; }

        public int Nota { get; set; }

        public string Texto { get; set; }

    }
}
