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
    class AutorArtigoMapper : AbstracMapper<AutorArtigo, int?, List<AutorArtigo>>, IAutorArtigoMapper
    {
        public AutorArtigoMapper(IContext ctx) : base(ctx)
        {
        }

        protected override string SelectAllCommandText => throw new NotImplementedException();

        protected override string SelectCommandText => throw new NotImplementedException();

        protected override string UpdateCommandText => throw new NotImplementedException();

        protected override CommandType UpdateCommandType => throw new NotImplementedException();

        protected override string DeleteCommandText => throw new NotImplementedException();

        protected override string InsertCommandText => throw new NotImplementedException();

        protected override CommandType InsertCommandType => throw new NotImplementedException();

        protected override void DeleteParameters(IDbCommand command, AutorArtigo e)
        {
            throw new NotImplementedException();
        }


        protected override AutorArtigo InsertParameters(AutorArtigo e)
        {
            throw new NotImplementedException();
        }

        protected override AutorArtigo Map(IDataRecord record)
        {
            throw new NotImplementedException();
        }

        protected override void SelectParameters(IDbCommand command, int? k)
        {
            throw new NotImplementedException();
        }

        protected override AutorArtigo UpdateEntityID(IDbCommand cmd, AutorArtigo e)
        {
            throw new NotImplementedException();
        }

        protected override AutorArtigo UpdateParameters(AutorArtigo e)
        {
            throw new NotImplementedException();
        }
    }
}
