﻿using DAL;
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
    class FicheiroPDFMapper : AbstracMapper<FicheiroPDF, int?, List<FicheiroPDF>>, IFicheiroPDFMapper
    {
        public FicheiroPDFMapper(IContext ctx) : base(ctx)
        {
        }

        protected override string SelectAllCommandText => throw new NotImplementedException();

        protected override string SelectCommandText => throw new NotImplementedException();

        protected override string UpdateCommandText => throw new NotImplementedException();

        protected override CommandType UpdateCommandType => throw new NotImplementedException();

        protected override string DeleteCommandText => throw new NotImplementedException();

        protected override string InsertCommandText => throw new NotImplementedException();

        protected override CommandType InsertCommandType => throw new NotImplementedException();

        protected override void DeleteParameters(IDbCommand command, FicheiroPDF e)
        {
            throw new NotImplementedException();
        }

        protected override FicheiroPDF InsertParameters(FicheiroPDF e)
        {
            throw new NotImplementedException();
        }

        protected override FicheiroPDF Map(IDataRecord record)
        {
            throw new NotImplementedException();
        }

        protected override void SelectParameters(IDbCommand command, int? k)
        {
            throw new NotImplementedException();
        }

        protected override FicheiroPDF UpdateEntityID(IDbCommand cmd, FicheiroPDF e)
        {
            throw new NotImplementedException();
        }

        protected override FicheiroPDF UpdateParameters(FicheiroPDF e)
        {
            throw new NotImplementedException();
        }
    }
}
