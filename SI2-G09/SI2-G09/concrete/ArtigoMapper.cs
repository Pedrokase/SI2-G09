﻿using DAL;
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

        protected override string SelectAllCommandText => throw new NotImplementedException();

        protected override string SelectCommandText => throw new NotImplementedException();

        protected override string UpdateCommandText => throw new NotImplementedException();

        protected override CommandType UpdateCommandType { get { return System.Data.CommandType.Text} }

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
            throw new NotImplementedException();
        }

        protected override void SelectParameters(IDbCommand command, int? k)
        {
            throw new NotImplementedException();
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
            using (IDbCommand cmd = context.createCommand())
            {
                cmd.CommandType = UpdateCommandType;
                cmd.CommandText = ChangeSubmissonCommandText;
                SqlParameter p1 = new SqlParameter("@conferencia_id", SqlDbType.Int);
                SqlParameter p2 = new SqlParameter("@data_corte", SqlDbType.Date);
                p1.Value = a.ID;
                p2.Value = dataCorte;
                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                int result = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return (result == 0) ? null : a;
            }
        }
    }
}
