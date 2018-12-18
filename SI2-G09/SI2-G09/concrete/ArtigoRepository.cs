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
    class ArtigoRepository : IArtigoRepository
    {
        private IContext context;
        public ArtigoRepository(IContext ctx)
        {
            context = ctx;
        }

        public IEnumerable<Artigo> Find(System.Func<Artigo, bool> criteria)
        {
            //Implementação muito pouco eficiente.  
            return FindAll().Where(criteria);
        }

        public IEnumerable<Artigo> FindAll()
        {
            return new ArtigoMapper(context).ReadAll();
        }
    }
}
