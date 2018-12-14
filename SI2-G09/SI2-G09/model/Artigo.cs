using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI2_G09.model
{
    public class Artigo
    {
		public int ID { get; set; }
		public virtual Conferencia Conferencia { get; set; }
		public string Resumo { get; set; }
		public DateTime DataSubmetido { get; set; }
		public string Estado { get; set; }
    }
}
