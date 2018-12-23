using DAL;
using SI2_G09.concrete;
using SI2_G09.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI2_G09.mapper
{
    class RevisorProxy : Revisor
    {
        private IContext context;
        private int? utilizadorID;
        public RevisorProxy(Revisor s, IContext ctx, int? utilizadorId) : base()
        {
            base.ID = s.ID;
            base.UserID = null;
            context = ctx;
        }

        public override Utilizador UserID
        {
            get
            {
                if (base.UserID == null) //lazy load
                {
                    RevisorMapper sm = new RevisorMapper(context);
                    base.UserID = sm.LoadUtilizadores(this);
                }
                return base.UserID;
            }

            set
            {
                base.UserID = value;
            }
        }
    }
}
