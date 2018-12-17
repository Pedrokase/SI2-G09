using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI2_G09.model
{
    public class ConferenciaUtilizador
    {
        public virtual Utilizador UserID { get; set; }
        public virtual Conferencia ConferenceID { get; set; }
        public DateTime DataRegisto { get; set; }

    }
}
