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
    //TODO Tid de AbstractMapper com dois id's
    class ArtigoMapper : AbstracMapper<Artigo, int?, List<Artigo>>, IArtigoMapper
    {
        public ArtigoMapper(IContext ctx) : base(ctx)
        {
        }

	    internal Conferencia LoadConference(Artigo article)
	    {
		    ConferenciaMapper cm = new ConferenciaMapper(context);
		    List<IDataParameter> parameters = new List<IDataParameter>();
		    parameters.Add(new SqlParameter("@id", article.Conferencia.Id));
		    int key = 0;
		    using (IDataReader rd = ExecuteReader("select conferenceID from artigo where conferenceID=@id", parameters))
		    {
			    if (rd.Read())
			    {
				    key = rd.GetInt32(0);
			    }

		    }

		    return cm.Read(key);
	    }

	    protected override string SelectAllCommandText { get { return "select * from Artigo"; } }

        protected override string SelectCommandText { get { return String.Format("{0} where ID=@id", SelectAllCommandText); } }

        protected override string UpdateCommandText => throw new NotImplementedException();

        protected override CommandType UpdateCommandType { get { return System.Data.CommandType.Text; } }

		protected override string DeleteCommandText => throw new NotImplementedException();

        protected override string InsertCommandText => throw new NotImplementedException();

        protected override CommandType InsertCommandType => throw new NotImplementedException();

        protected string ChangeSubmissonCommandText { get {
                return "update Artigo set estado='Rejeitado'" +
                " where conferenceID=@conferencia_id and data_submetido>@data_corte and estado != 'Aceite'";
            } }

        protected override void DeleteParameters(IDbCommand command, Artigo e)
        {
            throw new NotImplementedException();
        }


        protected override Artigo InsertParameters(Artigo e)
        {
            throw new NotImplementedException();
        }

        protected override Artigo Map(IDataRecord record)
        {
            Artigo a = new Artigo();
            //Conferencia c = new Conferencia();
            a.ID = record.GetInt32(0);
            //c.Id = record.GetInt32(1);
            a.Resumo = record.GetString(2);
            a.DataSubmetido = record.GetDateTime(3);
            a.Estado = record.GetString(4);
            return new ArtigoProxy(a,context, record.GetInt32(1));
        }

        protected override void SelectParameters(IDbCommand command, int? k)
        {
            SqlParameter p1 = new SqlParameter("@id", k);
            command.Parameters.Add(p1);
        }

        protected override Artigo UpdateEntityID(IDbCommand cmd, Artigo e)
        {
            throw new NotImplementedException();
        }

        protected override Artigo UpdateParameters(Artigo e)
        {
            throw new NotImplementedException();
        }

        public Artigo ChangeSubmission(Artigo a, DateTime dataCorte)
        {
            EnsureContext();
            SetDataCorte(a, dataCorte);
            using (IDbCommand cmd = context.createCommand())
            {
                
                cmd.CommandType = UpdateCommandType;
                cmd.CommandText = ChangeSubmissonCommandText;
                SqlParameter p1 = new SqlParameter("@conferencia_id", SqlDbType.Int);
                SqlParameter p2 = new SqlParameter("@data_corte", SqlDbType.Date);
                p1.Value = a.Conferencia.Id;
                p2.Value = dataCorte;
                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                int result = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return (result == 0) ? null : a;
            }
        }
        public bool SetDataCorte(Artigo a, DateTime dataCorte)
        {
            using(IDbCommand cmd = context.createCommand())
            {
                cmd.CommandType = UpdateCommandType;
                cmd.CommandText = "if @data_corte = NULL select @data_corte = data_revisao from Conferencia where ID = @conferencia_id";
                SqlParameter p1 = new SqlParameter("@data_corte", SqlDbType.Date);
                SqlParameter p2 = new SqlParameter("@conferencia_id", SqlDbType.Int);
                p1.Value = dataCorte;
                p2.Value = a.Conferencia.Id;
                int result = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return (result == 0) ? false : true;
            }
        }
    }
}
