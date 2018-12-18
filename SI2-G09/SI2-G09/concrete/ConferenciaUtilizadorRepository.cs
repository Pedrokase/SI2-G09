using DAL;
using SI2_G09.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI2_G09.concrete
{
    class ConferenciaUtilizadorRepository
    {
        private IContext context;
        public ConferenciaUtilizadorRepository(IContext ctx)
        {
            context = ctx;
        }
        public IEnumerable<ConferenciaUtilizador> Find(Func<ConferenciaUtilizador, bool> criteria)
        {
            //Implementação muito pouco eficiente.  
            return FindAll().Where(criteria);
        }

        public IEnumerable<ConferenciaUtilizador> FindAll()
        {
            return new ConferenciaUtilizadorMapper(context).ReadAll();
        }
    }
}
