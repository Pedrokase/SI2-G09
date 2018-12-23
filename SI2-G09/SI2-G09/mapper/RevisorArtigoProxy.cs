using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SI2_G09.concrete;
using SI2_G09.model;

namespace SI2_G09.mapper
{
	class RevisorArtigoProxy : RevisorArtigo
	{
		private IContext context;
		private int? articleId;
		private int? userId;

		public RevisorArtigoProxy(RevisorArtigo ra, IContext ctx, int articleId, int userId)
		{
		
            base.Nota = ra.Nota;
            base.Texto = ra.Texto;
            base.Revisor = null;
			base.ArtigoRevisto = null;
			context = ctx;
		}

		public override Artigo ArtigoRevisto
		{
			get
			{
				if (base.ArtigoRevisto == null)
				{
					RevisorArtigoMapper ram = new RevisorArtigoMapper(context);
					base.ArtigoRevisto = ram.LoadArtigos(this);
				}

				return base.ArtigoRevisto;
			}

			set { base.ArtigoRevisto = value; }
		}

		public override Revisor Revisor
		{
			get
			{
				if (base.Revisor == null)
				{
					RevisorArtigoMapper ram = new RevisorArtigoMapper(context);
					base.Revisor = ram.LoadRevisor(this);
				}

				return base.Revisor;
			}
			set { base.Revisor = value; }
		}
	}
}
