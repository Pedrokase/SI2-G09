using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI2_G09.model
{
    public class Conferencia
    {
		public int Id { get; set; }
		public string Nome { get; set; }
		public int Ano { get; set; }
		public string Acronimo { get; set; }
		public DateTime DataSubmissao { get; set; }
		public DateTime? DataRevisao { get; set; }
		public int President { get; set; }
		public int NotaMinima { get; set; }
    }
}