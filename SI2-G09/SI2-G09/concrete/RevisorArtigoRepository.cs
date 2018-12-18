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
    class RevisorArtigoRepository : IRevisorArtigoRepository
    {
        private IContext context;
        public RevisorArtigoRepository(IContext ctx)
        {
            context = ctx;
        }
        public IEnumerable<RevisorArtigo> Find(Func<RevisorArtigo, bool> criteria)
        {
            //Implementação muito pouco eficiente.  
            return FindAll().Where(criteria);
        }

        public IEnumerable<RevisorArtigo> FindAll()
        {
            return new RevisorArtigoMapper(context).ReadAll();
        }
    }
}
