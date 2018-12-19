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
    class UtilizadorInstituicaoMapper : AbstracMapper<UtilizadorInstituicao, int?, List<UtilizadorInstituicao>>, IUtilizadorInstituicaoMapper
    {
        public UtilizadorInstituicaoMapper(IContext ctx) : base(ctx)
        {
        }

        protected override string SelectAllCommandText => throw new NotImplementedException();

        protected override string SelectCommandText => throw new NotImplementedException();

        protected override string UpdateCommandText => throw new NotImplementedException();

        protected override string DeleteCommandText => throw new NotImplementedException();

        protected override string InsertCommandText => throw new NotImplementedException();

        protected override void DeleteParameters(IDbCommand command, UtilizadorInstituicao e)
        {
            throw new NotImplementedException();
        }

        protected override void InsertParameters(IDbCommand command, UtilizadorInstituicao e)
        {
            throw new NotImplementedException();
        }

        protected override UtilizadorInstituicao Map(IDataRecord record)
        {
            throw new NotImplementedException();
        }

        protected override void SelectParameters(IDbCommand command, int? k)
        {
            throw new NotImplementedException();
        }

        protected override UtilizadorInstituicao UpdateEntityID(IDbCommand cmd, UtilizadorInstituicao e)
        {
            throw new NotImplementedException();
        }

        protected override void UpdateParameters(IDbCommand command, UtilizadorInstituicao e)
        {
            throw new NotImplementedException();
        }
    }
}
