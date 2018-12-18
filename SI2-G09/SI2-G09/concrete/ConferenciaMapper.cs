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
        protected override string SelectAllCommandText => throw new NotImplementedException();

        protected override string SelectCommandText => throw new NotImplementedException();

        protected override string UpdateCommandText => throw new NotImplementedException();

        protected override string DeleteCommandText => throw new NotImplementedException();

        protected override string InsertCommandText => throw new NotImplementedException();

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
            throw new NotImplementedException();
        }

        protected override void SelectParameters(IDbCommand command, int? k)
        {
            throw new NotImplementedException();
        }

        protected override Conferencia UpdateEntityID(IDbCommand cmd, Conferencia e)
        {
            throw new NotImplementedException();
        }

        protected override void UpdateParameters(IDbCommand command, Conferencia e)
        {
            throw new NotImplementedException();
        }
    }
}
