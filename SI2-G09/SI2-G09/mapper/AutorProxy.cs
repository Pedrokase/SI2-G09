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
    class AutorProxy : Autor
    {
        private IContext context;
        private int? utilizadorID;
        public AutorProxy(Autor s, IContext ctx, int utilizadorId) : base()
        {
            Utilizador a = new Utilizador();
            a.ID = utilizadorId;
            base.UserID = a;
            context = ctx;
        }

        public override Utilizador UserID
        {
            get
            {
                if (base.UserID == null) //lazy load
                {
                    AutorMapper sm = new AutorMapper(context);
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
