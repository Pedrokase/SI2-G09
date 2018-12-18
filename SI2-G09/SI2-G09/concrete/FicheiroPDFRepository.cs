using DAL;
using SI2_G09.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI2_G09.concrete
{
    class FicheiroPDFRepository
    {
        private IContext context;
        public FicheiroPDFRepository(IContext ctx)
        {
            context = ctx;
        }
        public IEnumerable<FicheiroPDF> Find(Func<FicheiroPDF, bool> criteria)
        {
            //Implementação muito pouco eficiente.  
            return FindAll().Where(criteria);
        }

        public IEnumerable<FicheiroPDF> FindAll()
        {
            return new FicheiroPDFMapper(context).ReadAll();
        }
    }
}
