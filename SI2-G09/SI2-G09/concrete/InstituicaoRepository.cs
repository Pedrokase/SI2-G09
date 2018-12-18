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
    class InstituicaoRepository : IInstituicaoRepository
    {
        private IContext context;
        public InstituicaoRepository(IContext ctx)
        {
            context = ctx;
        }
        public IEnumerable<Instituicao> Find(Func<Instituicao, bool> criteria)
        {
            //Implementação muito pouco eficiente.  
            return FindAll().Where(criteria);
        }

        public IEnumerable<Instituicao> FindAll()
        {
            return new InstituicaoMapper(context).ReadAll();
        }
    }
}
