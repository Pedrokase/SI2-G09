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

    class ConferenciaMapper : AbstracMapper<Conferencia, int?, List<Conferencia>>, IConferenciaMapper
    {
        public ConferenciaMapper(IContext ctx) : base(ctx)
        {
        }

        protected override string SelectAllCommandText { get { return "select * from Conferencia"; } }

        protected override string SelectCommandText { get { return String.Format("{0} where ID=@id", SelectAllCommandText); } }

        protected override string UpdateCommandText => throw new NotImplementedException();

        protected override CommandType UpdateCommandType { get { return System.Data.CommandType.StoredProcedure;} }

        protected override string DeleteCommandText => throw new NotImplementedException();

        protected override string InsertCommandText => throw new NotImplementedException();

        protected string UpdateNotaConferenciaCommandText { get { return "UpdateNotaConferencia"; } }
        protected string UpdateDataSubmissaoCommandText { get { return "UpdateDataSubmissao"; } }
        protected string UpdateDataRevisaoCommandText { get { return "UpdateDataRevisao"; } }
        protected string UpdatePresidenteCommandText { get { return "UpdatePresidente"; } }
        protected string UpdateAcronimoCommandText { get { return "UpdateAcronimo"; } }
        protected string UpdateNomeCommandText { get { return "UpdateNome"; } }
		protected string ReturnAcceptedSubmissionsPercentage { get { return "AcceptSubmissionRate";} }

        


		protected override CommandType InsertCommandType => throw new NotImplementedException();

        protected override void DeleteParameters(IDbCommand command, Conferencia e)
        {
            throw new NotImplementedException();
        }

       

        protected override Conferencia Map(IDataRecord record)
        {
            Conferencia c = new Conferencia();
            c.Id = record.GetInt32(0);
            c.Nome = record.GetString(1);
            c.Ano = record.GetInt32(2);
            c.Acronimo = record.IsDBNull(3) ? null : record.GetString(3);
            c.DataSubmissao = record.GetDateTime(4);
            //c.DataSubmissao = DateTime.Parse(record.GetInt32(4).ToString());
            c.DataRevisao = record.IsDBNull(5) ? (DateTime?)null : record.GetDateTime(5);
            c.President = record.GetInt32(6);
            c.NotaMinima = record.GetInt32(7);
            return c;
        }

        protected override void SelectParameters(IDbCommand cmd, int? k)
        {
            SqlParameter p1 = new SqlParameter("@id", k);
            cmd.Parameters.Add(p1);
        }

        protected override Conferencia UpdateEntityID(IDbCommand cmd, Conferencia e)
        {
            throw new NotImplementedException();
        }

        protected override Conferencia UpdateParameters(Conferencia e)
        {
            Conferencia c;
            c = UpdateNotaConferencia(e);
            c = UpdateDataSubmissao(e);
            if(e.DataRevisao != null)
                c = UpdateDataRevisao(e);
            c = UpdatePresidente(e);
            if(e.Acronimo != null)
                c = UpdateAcronimo(e);
            c = UpdateNome(e);
            return c;
        }

        public Conferencia UpdateNotaConferencia(Conferencia e)
        {
            EnsureContext();
            using (IDbCommand cmd = context.createCommand())
            {
                cmd.CommandType = UpdateCommandType;
                cmd.CommandText = UpdateNotaConferenciaCommandText;
                SqlParameter p1 = new SqlParameter("@conferenceID", SqlDbType.Int);
                SqlParameter p2 = new SqlParameter("@nota", e.NotaMinima);
                
                //p1.Direction = ParameterDirection.InputOutput;
                p1.Value = e.Id;
                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                //var param = cmd.Parameters["@nota"] as SqlParameter;
                //e.NotaMinima = int.Parse(param.Value.ToString());
                int result = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return (result == 0) ? null : e;
            }
        }
        protected Conferencia UpdateDataSubmissao(Conferencia e)
        {
            EnsureContext();
            using (IDbCommand cmd = context.createCommand())
            {
                SqlParameter p1 = new SqlParameter("@conferenceID", SqlDbType.Int);
                SqlParameter p2 = new SqlParameter("@date", e.DataSubmissao);
                cmd.CommandType = UpdateCommandType;
                cmd.CommandText = UpdateDataSubmissaoCommandText;
                p1.Value = e.Id;
                //var param = cmd.Parameters["@datasubmissao"] as SqlParameter;
                //e.DataSubmissao = Convert.ToDateTime(param.Value.ToString());
                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                int result = cmd.ExecuteNonQuery();
                return (result == 0) ? null : e;
            }
        }
        protected Conferencia UpdateDataRevisao(Conferencia e)
        {
            EnsureContext();
            using (IDbCommand cmd = context.createCommand())
            {
                SqlParameter p1 = new SqlParameter("@conferenceID", SqlDbType.Int);
                SqlParameter p2 = new SqlParameter("@date", e.DataRevisao);
                cmd.CommandType = UpdateCommandType;
                cmd.CommandText = UpdateDataRevisaoCommandText;
                p1.Value = e.Id;
                //var param = cmd.Parameters["@datarevisao"] as SqlParameter;
                //e.DataRevisao = Convert.ToDateTime(param.Value.ToString());
                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                int result = cmd.ExecuteNonQuery();
                return (result == 0) ? null : e;
            }
        }
        protected Conferencia UpdatePresidente(Conferencia e)
        {
            EnsureContext();
            using (IDbCommand cmd = context.createCommand())
            {
                SqlParameter p1 = new SqlParameter("@conferenceID", SqlDbType.Int);
                SqlParameter p2 = new SqlParameter("@newPresidentID", e.President);
                cmd.CommandType = UpdateCommandType;
                cmd.CommandText = UpdatePresidenteCommandText;
                //var param = cmd.Parameters["@presidente"] as SqlParameter;
                //e.President = int.Parse(param.Value.ToString());
                p1.Value = e.Id;
                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                int result = cmd.ExecuteNonQuery();
                return (result == 0) ? null : e;
            }
        }
        protected Conferencia UpdateAcronimo(Conferencia e)
        {
            EnsureContext();
            using (IDbCommand cmd = context.createCommand())
            {
                SqlParameter p1 = new SqlParameter("@id", SqlDbType.Int);
                SqlParameter p2 = new SqlParameter("@newAcronimo", e.Acronimo);
                cmd.CommandType = UpdateCommandType;
                cmd.CommandText = UpdateAcronimoCommandText;
                //var param = cmd.Parameters["@acronimo"] as SqlParameter;
                //e.Acronimo = param.Value.ToString();
                p1.Value = e.Id;
                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                int result = cmd.ExecuteNonQuery();
                return (result == 0) ? null : e;
            }
        }
        protected Conferencia UpdateNome(Conferencia e)
        {
            EnsureContext();
            using (IDbCommand cmd = context.createCommand())
            {
                cmd.CommandType = UpdateCommandType;
                cmd.CommandText = UpdateNomeCommandText;
                SqlParameter p1 = new SqlParameter("@conferenceID", SqlDbType.Int);
                SqlParameter p2 = new SqlParameter("@newName", e.Nome);

                //p1.Direction = ParameterDirection.InputOutput;
                p1.Value = e.Id;
                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                //var param = cmd.Parameters["@nota"] as SqlParameter;
                //e.NotaMinima = int.Parse(param.Value.ToString());
                int result = cmd.ExecuteNonQuery();
                return (result == 0) ? null : e;
            }
        }

        protected override Conferencia InsertParameters(Conferencia e)
        {
            throw new NotImplementedException();
        }

	    public int GetAcceptedSubmissionsPercentage(Conferencia e)
	    {
			EnsureContext();
		    using (IDbCommand cmd = context.createCommand())
		    {
			    SqlParameter p1 = new SqlParameter("@conferencia_id", SqlDbType.Int);
				SqlParameter retVal = new SqlParameter("retVal", SqlDbType.Int)
				{
					Direction = ParameterDirection.ReturnValue
				};

				cmd.CommandType = CommandType.StoredProcedure;
			    cmd.CommandText = ReturnAcceptedSubmissionsPercentage;

			    p1.Value = e.Id;

			    cmd.Parameters.Add(p1);
			    cmd.Parameters.Add(retVal);

			    if (cmd.ExecuteNonQuery() == 0)
			    {
					throw new Exception();
			    }

			    return (int) retVal.Value;
		    }
	    }
    }
}
