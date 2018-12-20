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

        protected override string SelectCommandText => throw new NotImplementedException();

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

        protected override void DeleteParameters(IDbCommand command, Conferencia e)
        {
            throw new NotImplementedException();
        }

        protected override void InsertParameters(IDbCommand command, Conferencia e)
        {
            throw new NotImplementedException();
        }

        protected override Conferencia Map(IDataRecord record)
        {
            Conferencia c = new Conferencia();
            c.Id = record.GetInt32(0);
            c.Nome = record.GetString(1);
            c.Acronimo = record.GetString(2);
            c.DataSubmissao = DateTime.Parse(record.GetInt32(3).ToString());
            c.DataRevisao = DateTime.Parse(record.GetInt32(4).ToString());
            c.President = record.GetInt32(5);
            c.NotaMinima = record.GetInt32(6);
            return c;
        }

        protected override void SelectParameters(IDbCommand command, int? k)
        {
            throw new NotImplementedException();
        }

        protected override Conferencia UpdateEntityID(IDbCommand cmd, Conferencia e)
        {
            throw new NotImplementedException();
        }

        protected override Conferencia UpdateParameters(Conferencia e)
        {
            Conferencia c = UpdateNotaConferencia(e);
            c = UpdateDataSubmissao(e);
            c = UpdateDataRevisao(e);
            c = UpdatePresidente(e);
            c = UpdateAcronimo(e);
            c = UpdateNome(e);
            return c;
        }

        protected Conferencia UpdateNotaConferencia(Conferencia e)
        {
            EnsureContext();
            using (IDbCommand cmd = context.createCommand())
            {
                SqlParameter p1 = new SqlParameter("@id", SqlDbType.Int);
                SqlParameter p2 = new SqlParameter("@nota", e.NotaMinima);
                cmd.CommandText = UpdateNotaConferenciaCommandText;
                p1.Direction = ParameterDirection.InputOutput;
                p1.Value = e.Id;
                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                //var param = cmd.Parameters["@nota"] as SqlParameter;
                //e.NotaMinima = int.Parse(param.Value.ToString());
                int result = cmd.ExecuteNonQuery();
                return (result == 0) ? null : e;
            }
        }
        protected Conferencia UpdateDataSubmissao(Conferencia e)
        {
            EnsureContext();
            using (IDbCommand cmd = context.createCommand())
            {
                SqlParameter p1 = new SqlParameter("@id", SqlDbType.Int);
                SqlParameter p2 = new SqlParameter("@datasubmissao", e.DataSubmissao);
                cmd.CommandType = SelectAllCommandType;
                cmd.CommandText = UpdateDataSubmissaoCommandText;
                var param = cmd.Parameters["@datasubmissao"] as SqlParameter;
                e.DataSubmissao = Convert.ToDateTime(param.Value.ToString());
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
                SqlParameter p1 = new SqlParameter("@id", SqlDbType.Int);
                SqlParameter p2 = new SqlParameter("@datarevisao", e.DataRevisao);
                cmd.CommandType = SelectAllCommandType;
                cmd.CommandText = UpdateDataRevisaoCommandText;
                var param = cmd.Parameters["@datarevisao"] as SqlParameter;
                e.DataRevisao = Convert.ToDateTime(param.Value.ToString());
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
                SqlParameter p1 = new SqlParameter("@id", SqlDbType.Int);
                SqlParameter p2 = new SqlParameter("@presidente", e.President);
                cmd.CommandType = SelectAllCommandType;
                cmd.CommandText = UpdatePresidenteCommandText;
                var param = cmd.Parameters["@presidente"] as SqlParameter;
                e.President = int.Parse(param.Value.ToString());
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
                SqlParameter p2 = new SqlParameter("@acronimo", e.Acronimo);
                cmd.CommandType = SelectAllCommandType;
                cmd.CommandText = UpdateAcronimoCommandText;
                var param = cmd.Parameters["@acronimo"] as SqlParameter;
                e.Acronimo = param.Value.ToString();
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
                SqlParameter p1 = new SqlParameter("@id", SqlDbType.Int);
                SqlParameter p2 = new SqlParameter("@data", e.Nome);
                cmd.CommandType = SelectAllCommandType;
                cmd.CommandText = UpdateNomeCommandText;
                var param = cmd.Parameters["@nome"] as SqlParameter;
                e.Nome = param.Value.ToString();
                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                int result = cmd.ExecuteNonQuery();
                return (result == 0) ? null : e;
            }
        }
    }
}
