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
    class RevisorMapper : AbstracMapper<Revisor, int?, List<Revisor>>, IRevisorMapper
    { 
        public RevisorMapper(IContext ctx) : base(ctx)
        {
        }

        protected override string SelectAllCommandText => throw new NotImplementedException();

        protected override string SelectCommandText => throw new NotImplementedException();

        protected override string UpdateCommandText => throw new NotImplementedException();

        protected override string DeleteCommandText => throw new NotImplementedException();

        protected override string InsertCommandText => throw new NotImplementedException();

        protected override void DeleteParameters(IDbCommand command, Revisor e)
        {
            throw new NotImplementedException();
        }

        protected override void InsertParameters(IDbCommand command, Revisor e)
        {
            throw new NotImplementedException();
        }

        protected override Revisor Map(IDataRecord record)
        {
            throw new NotImplementedException();
        }

        protected override void SelectParameters(IDbCommand command, int? k)
        {
            throw new NotImplementedException();
        }

        protected override Revisor UpdateEntityID(IDbCommand cmd, Revisor e)
        {
            throw new NotImplementedException();
        }

        protected override void UpdateParameters(IDbCommand command, Revisor e)
        {
            throw new NotImplementedException();
        }
    }
}
