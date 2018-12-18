using DAL;
using SI2_G09.dal;
using SI2_G09.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI2_G09.concrete
{
    class UtilizadorRepository : IUtilizadorRepository
    {
        private IContext context;
        public UtilizadorRepository(IContext ctx)
        {
            context = ctx;
        }
        public IEnumerable<Utilizador> Find(Func<Utilizador, bool> criteria)
        {
            //Implementação muito pouco eficiente.  
            return FindAll().Where(criteria);
        }

        public IEnumerable<Utilizador> FindAll()
        {
            return new UtilizadorMapper(context).ReadAll();
        }
    }
}
