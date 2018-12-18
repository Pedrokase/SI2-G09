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
    class RevisorRepository : IRevisorRepository
    {
        private IContext context;
        public RevisorRepository(IContext ctx)
        {
            context = ctx;
        }
        public IEnumerable<Revisor> Find(Func<Revisor, bool> criteria)
        {
            //Implementação muito pouco eficiente.  
            return FindAll().Where(criteria);
        }

        public IEnumerable<Revisor> FindAll()
        {
            return new RevisorMapper(context).ReadAll();
        }
    }
}
