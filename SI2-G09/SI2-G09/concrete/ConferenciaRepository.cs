﻿using DAL;
using SI2_G09.dal;
using SI2_G09.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI2_G09.concrete
{
    class ConferenciaRepository : IConferenciaRepository
    {
        private IContext context;
        public ConferenciaRepository(IContext ctx)
        {
            context = ctx;
        }

        public IEnumerable<Conferencia> Find(System.Func<Conferencia, bool> criteria)
        {
            //Implementação muito pouco eficiente.  
            return FindAll().Where(criteria);
        }

        public IEnumerable<Conferencia> FindAll()
        {
            return new ConferenciaMapper(context).ReadAll();
        }
    }
}
