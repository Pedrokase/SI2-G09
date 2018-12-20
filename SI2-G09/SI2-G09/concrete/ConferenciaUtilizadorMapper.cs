using DAL;
using DAL.mapper;
using SI2_G09.mapper;
using SI2_G09.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI2_G09.concrete
{
    class ConferenciaUtilizadorMapper : AbstracMapper<ConferenciaUtilizador, int?, List<ConferenciaUtilizador>>, IConferenciaUtilizadorMapper
    {
        public ConferenciaUtilizadorMapper(IContext ctx) : base(ctx)
        {
        }

        protected override string SelectAllCommandText => throw new NotImplementedException();

        protected override string SelectCommandText => throw new NotImplementedException();

        protected override string UpdateCommandText => throw new NotImplementedException();

        protected override CommandType UpdateCommandType => throw new NotImplementedException();

        protected override string DeleteCommandText => throw new NotImplementedException();

        protected override string InsertCommandText => throw new NotImplementedException();

        protected override void DeleteParameters(IDbCommand command, ConferenciaUtilizador e)
        {
            throw new NotImplementedException();
        }

        protected override void InsertParameters(IDbCommand command, ConferenciaUtilizador e)
        {
            throw new NotImplementedException();
        }

        protected override ConferenciaUtilizador Map(IDataRecord record)
        {
            throw new NotImplementedException();
        }

        protected override void SelectParameters(IDbCommand command, int? k)
        {
            throw new NotImplementedException();
        }

        protected override ConferenciaUtilizador UpdateEntityID(IDbCommand cmd, ConferenciaUtilizador e)
        {
            throw new NotImplementedException();
        }

        protected override ConferenciaUtilizador UpdateParameters(ConferenciaUtilizador e)
        {
            throw new NotImplementedException();
        }
    }
}
