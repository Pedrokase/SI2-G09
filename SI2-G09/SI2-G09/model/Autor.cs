using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI2_G09.model
{
    public class Autor
    {
        public int ID { get; set; }
        public virtual Utilizador UserID { get; set; }
    }
}
