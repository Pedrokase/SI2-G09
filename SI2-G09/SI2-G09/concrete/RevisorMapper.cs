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
    class RevisorMapper : AbstracMapper<Revisor, int?, List<Revisor>>, IRevisorMapper
    {
        internal Utilizador LoadUtilizadores(Revisor r)
        {
            UtilizadorMapper rm = new UtilizadorMapper(context);
            List<IDataParameter> parameters = new List<IDataParameter>();
            //parameters.Add(new SqlParameter("@id", r.UserID.ID));
            parameters.Add(new SqlParameter("@id", 1));
            using (IDataReader rd = ExecuteReader("select ID from Utilizador where ID=@id", parameters))
            {
                if (rd.Read())
                {
                    int key = rd.GetInt32(0);
                    return rm.Read(key);
                }

            }
            return null;
        }
        public RevisorMapper(IContext ctx) : base(ctx)
        {
        }

        protected override string SelectAllCommandText { get { return "select * from Revisor"; } }

        protected override string SelectCommandText { get { return String.Format("{0} where userID=@id", SelectAllCommandText); } }

        protected override string UpdateCommandText => throw new NotImplementedException();

        protected override CommandType UpdateCommandType => throw new NotImplementedException();

        protected override string DeleteCommandText => throw new NotImplementedException();

        protected override string InsertCommandText { get { return "UtilizadorToRevisor"; } }

        protected string CompatibleReviewersCommandText { get { return "SELECT * FROM listCompatibleReviewers(@conferenceID, @articleID)"; } }

        protected override CommandType InsertCommandType { get { return System.Data.CommandType.StoredProcedure; } }

        protected override void DeleteParameters(IDbCommand command, Revisor e)
        {
            throw new NotImplementedException();
        }

        protected override Revisor InsertParameters(Revisor e)
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

        protected override Revisor Map(IDataRecord record)
        {
            Revisor r = new Revisor();
            /*Utilizador u = new Utilizador();
            u.ID = record.GetInt32(0);
            r.UserID = u;*/
            return new RevisorProxy(r, context, record.GetInt32(0));
        }

        protected override void SelectParameters(IDbCommand command, int? k)
        {
            SqlParameter p = new SqlParameter("@id", k);
            command.Parameters.Add(p);
        }

        protected override Revisor UpdateEntityID(IDbCommand cmd, Revisor e)
        {
            throw new NotImplementedException();
        }

        protected override Revisor UpdateParameters(Revisor e)
        {
            throw new NotImplementedException();
        }
        public List<object> CompatibleReviewers(int conferenceID, int articleID)
        {
            EnsureContext();
            using (IDbCommand cmd = context.createCommand())
            {
                cmd.CommandText = CompatibleReviewersCommandText;
                SqlParameter p1 = new SqlParameter("@conferenceID", SqlDbType.Int);
                SqlParameter p2 = new SqlParameter("@articleID", SqlDbType.Int);

                p1.Direction = ParameterDirection.Input;
                p2.Direction = ParameterDirection.Input;
                p1.Value = conferenceID;
                p2.Value = articleID;

                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);

                IDataReader reader = cmd.ExecuteReader();
                cmd.Parameters.Clear();
                List<object> result = new List<object>();
                while (reader.Read())
                {
                    result.Add(reader[0]);
                }
                return result;
            }
        }

        }
}
