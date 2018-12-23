using DAL;
using SI2_G09.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SI2_G09.concrete;

namespace SI2_G09.mapper
{
    class ArtigoProxy : Artigo
    {
        private IContext context;
	    private int? conferenceId;
        public ArtigoProxy(Artigo article, IContext ctx, int conferenceId) : base()
        {
			Conferencia conf = new Conferencia();
            base.ID = article.ID;
            base.DataSubmetido = article.DataSubmetido;
            base.Resumo = article.Resumo;
            base.Estado = article.Estado;
	        conf.Id = conferenceId;
	        base.Conferencia = conf;
	        context = ctx;
        }

	    public override Conferencia Conferencia
	    {
		    get
		    {
			    if (base.Conferencia == null)
			    {
				    ArtigoMapper am = new ArtigoMapper(context);
				    base.Conferencia = am.LoadConference(this);
			    }

			    return base.Conferencia;
		    }
		    set { base.Conferencia = value; }
	    }
    }
}
