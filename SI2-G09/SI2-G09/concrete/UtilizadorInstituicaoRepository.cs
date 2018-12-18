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
    class UtilizadorInstituicaoRepository : IUtilizadorInstituicaoRepository
    {
        private IContext context;
        public UtilizadorInstituicaoRepository(IContext ctx)
        {
            context = ctx;
        }
        public IEnumerable<UtilizadorInstituicao> Find(Func<UtilizadorInstituicao, bool> criteria)
        {
            //Implementação muito pouco eficiente.  
            return FindAll().Where(criteria);
        }

        public IEnumerable<UtilizadorInstituicao> FindAll()
        {
            return new UtilizadorInstituicaoMapper(context).ReadAll();
        }
    }
}
