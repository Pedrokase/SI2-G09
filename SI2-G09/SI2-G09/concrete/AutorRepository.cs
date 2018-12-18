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
    class AutorRepository : IAutorRepository
    {
        private IContext context;
        public AutorRepository(IContext ctx)
        {
            context = ctx;
        }

        public IEnumerable<Autor> Find(System.Func<Autor, bool> criteria)
        {
            //Implementação muito pouco eficiente.  
            return FindAll().Where(criteria);
        }

        public IEnumerable<Autor> FindAll()
        {
            return new AutorMapper(context).ReadAll();
        }
    }
}
