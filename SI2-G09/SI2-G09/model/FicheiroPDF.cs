using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI2_G09.model
{
    public class FicheiroPDF
    {
        public int FileVersion { get; set; }
        public virtual Artigo ArtigoFicheiroPDF { get; set; }
    }
}
