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
    class AutorArtigoRepository : IAutorArtigoRepository
    {
        private IContext context;
        public AutorArtigoRepository(IContext ctx)
        {
            context = ctx;
        }

        public IEnumerable<AutorArtigo> Find(System.Func<AutorArtigo, bool> criteria)
        {
            //Implementação muito pouco eficiente.  
            return FindAll().Where(criteria);
        }

        public IEnumerable<AutorArtigo> FindAll()
        {
            return new AutorArtigoMapper(context).ReadAll();
        }
    }
}
