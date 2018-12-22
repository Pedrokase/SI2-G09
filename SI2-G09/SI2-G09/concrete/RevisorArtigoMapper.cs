using DAL;
using DAL.mapper;
using SI2_G09.mapper;
using SI2_G09.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI2_G09.concrete
{
    class RevisorArtigoMapper : AbstracMapper<RevisorArtigo, int?, List<RevisorArtigo>>, IRevisorArtigoMapper
    {
		private string RegisterArticleProcedure
		{
			get { return "RegistoRevisao"; }
		}

        public RevisorArtigoMapper(IContext ctx) : base(ctx)
        {
        }

	    protected override string SelectAllCommandText { get { return "select * from Revisor_Artigo"; } }

	    protected override string SelectCommandText { get { return String.Format("{0} where userID=@userID AND ID=@ID AND conferenceID=@conferenceID", SelectAllCommandText); } }

		protected override string UpdateCommandText => throw new NotImplementedException();

        protected override CommandType UpdateCommandType => throw new NotImplementedException();

        protected override string DeleteCommandText => throw new NotImplementedException();

        protected override string InsertCommandText => throw new NotImplementedException();

        protected override CommandType InsertCommandType => throw new NotImplementedException();

        protected override void DeleteParameters(IDbCommand command, RevisorArtigo e)
        {
            throw new NotImplementedException();
        }

        protected override RevisorArtigo InsertParameters(RevisorArtigo e)
        {
            throw new NotImplementedException();
        }

        protected override RevisorArtigo Map(IDataRecord record)
        {
			RevisorArtigo ra = new RevisorArtigo();
			Utilizador user = new Utilizador();
			Artigo article = new Artigo();
			Conferencia conference = new Conferencia();
	        
	        user.ID = record.GetInt32(0);
			article.ID = record.GetInt32(1);
			conference.Id = record.GetInt32(2);
	        article.Conferencia = conference;

			ra.Revisor = user;
	        ra.ArtigoRevisto = article;
	        ra.Nota = record.GetInt32(3);
	        ra.Texto = record.GetString(4);
	        return ra;
        }

        protected override void SelectParameters(IDbCommand command, int? k)
        {
            throw new NotImplementedException();
        }

        protected override RevisorArtigo UpdateEntityID(IDbCommand cmd, RevisorArtigo e)
        {
            throw new NotImplementedException();
        }

        protected override RevisorArtigo UpdateParameters(RevisorArtigo e)
        {
            throw new NotImplementedException();
        }

	    public RevisorArtigo RegisterArticle(RevisorArtigo e, int grade, string text)
	    {
			EnsureContext();
		    using (IDbCommand cmd = context.createCommand())
		    {
			    SqlParameter userIdParam = new SqlParameter("@user_id", SqlDbType.Int);
				SqlParameter articleIdParam = new SqlParameter("@artigo_id", SqlDbType.Int);
			    SqlParameter conferenceIdParam = new SqlParameter("@conferencia_id", SqlDbType.Int);
			    SqlParameter gradeParam = new SqlParameter("@nota", SqlDbType.Int);
				SqlParameter articleTextParam = new SqlParameter("@texto", SqlDbType.VarChar, 200);

			    cmd.CommandType = CommandType.StoredProcedure;
			    cmd.CommandText = RegisterArticleProcedure;

			    userIdParam.Value = e.Revisor.ID;
			    articleIdParam.Value = e.ArtigoRevisto.ID;
			    conferenceIdParam.Value = e.ArtigoRevisto.Conferencia.Id;
			    gradeParam.Value = grade;
			    articleTextParam.Value = text;

			    cmd.Parameters.Add(userIdParam);
			    cmd.Parameters.Add(articleIdParam);
			    cmd.Parameters.Add(conferenceIdParam);
			    cmd.Parameters.Add(gradeParam);
			    cmd.Parameters.Add(articleTextParam);

			    cmd.ExecuteNonQuery();
			    return e;
		    }
		}
    }
}
