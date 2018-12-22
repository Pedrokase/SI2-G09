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
    class UtilizadorMapper : AbstracMapper<Utilizador, int?, List<Utilizador>>, IUtilizadorMapper
    {
        public UtilizadorMapper(IContext ctx) : base(ctx)
        {
        }

        protected override string SelectAllCommandText { get { return "select * from Utilizador"; } }

        protected override string SelectCommandText { get { return String.Format("{0} where ID=@id", SelectAllCommandText); } }

        protected override string UpdateCommandText => throw new NotImplementedException();

        protected override CommandType UpdateCommandType => throw new NotImplementedException();

        protected override string DeleteCommandText => throw new NotImplementedException();

        protected override string InsertCommandText => throw new NotImplementedException();

        protected override CommandType InsertCommandType => throw new NotImplementedException();

        protected override void DeleteParameters(IDbCommand command, Utilizador e)
        {
            throw new NotImplementedException();
        }


        protected override Utilizador InsertParameters(Utilizador e)
        {
            throw new NotImplementedException();
        }

        protected override Utilizador Map(IDataRecord record)
        {
            Utilizador u = new Utilizador();
            u.ID = record.GetInt32(0);
            u.Email = record.GetString(1);
            u.Nome = record.GetString(2);
            return u;
        }

        protected override void SelectParameters(IDbCommand command, int? k)
        {
            SqlParameter p1 = new SqlParameter("@id", k);
            command.Parameters.Add(p1);
        }

        protected override Utilizador UpdateEntityID(IDbCommand cmd, Utilizador e)
        {
            throw new NotImplementedException();
        }

        protected override Utilizador UpdateParameters(Utilizador e)
        {
            throw new NotImplementedException();
        }
    }
}
