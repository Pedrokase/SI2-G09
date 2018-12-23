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
    class AutorMapper : AbstracMapper<Autor, int?, List<Autor>>, IAutorMapper
    {
        internal Utilizador LoadUtilizadores(Autor r)
        {
            UtilizadorMapper rm = new UtilizadorMapper(context);
            List<IDataParameter> parameters = new List<IDataParameter>();
            parameters.Add(new SqlParameter("@id", r.UserID.ID));
            //parameters.Add(new SqlParameter("@id", r.ID));
            int key = 0;
            using (IDataReader rd = ExecuteReader("select userID from Autor where userID=@id", parameters))
            {
                if (rd.Read())
                {
                    key = rd.GetInt32(0);

                }

            }
            return rm.Read(key);
        }
        public AutorMapper(IContext ctx) : base(ctx)
        {
        }

        protected override string SelectAllCommandText { get { return "select * from Autor"; } }

        protected override string SelectCommandText { get { return String.Format("{0} where userID=@id", SelectAllCommandText); } }

        protected override string UpdateCommandText => throw new NotImplementedException();

        protected override CommandType UpdateCommandType => throw new NotImplementedException();

        protected override string DeleteCommandText => throw new NotImplementedException();

        protected override string InsertCommandText { get { return "UtilizadorToAutor"; } }

        protected override CommandType InsertCommandType { get { return System.Data.CommandType.StoredProcedure; } }

        protected override void DeleteParameters(IDbCommand command, Autor e)
        {
            throw new NotImplementedException();
        }

        protected override Autor InsertParameters(Autor e)
        {
            EnsureContext();
            using (IDbCommand cmd = context.createCommand())
            {
                cmd.CommandType = InsertCommandType;
                cmd.CommandText = InsertCommandText;
                SqlParameter p1 = new SqlParameter("@user_mail", SqlDbType.NVarChar);
                Utilizador u = e.UserID;
                p1.Value = u.Email;
                cmd.Parameters.Add(p1);
                int result = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return (result == 0) ? null : e;
            }
        }

        protected override Autor Map(IDataRecord record)
        {
            Autor r = new Autor();
            Utilizador u = new Utilizador();
            u.ID = record.GetInt32(0);
            r.UserID = u;
            return new AutorProxy(r, context, record.GetInt32(0));
        }

        protected override void SelectParameters(IDbCommand command, int? k)
        {
            SqlParameter p = new SqlParameter("@id", k);
            command.Parameters.Add(p);
        }

        protected override Autor UpdateEntityID(IDbCommand cmd, Autor e)
        {
            throw new NotImplementedException();
        }

        protected override Autor UpdateParameters(Autor e)
        {
            throw new NotImplementedException();
        }
    }
}
