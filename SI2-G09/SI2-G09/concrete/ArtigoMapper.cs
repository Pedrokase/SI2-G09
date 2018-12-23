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
    //TODO Tid de AbstractMapper com dois id's
    class ArtigoMapper : AbstracMapper<Artigo, int?, List<Artigo>>, IArtigoMapper
    {
        public ArtigoMapper(IContext ctx) : base(ctx)
        {
        }

	    internal Conferencia LoadConference(Artigo article)
	    {
		    ConferenciaMapper cm = new ConferenciaMapper(context);
		    List<IDataParameter> parameters = new List<IDataParameter>();
		    parameters.Add(new SqlParameter("@id", article.Conferencia.Id));
		    int key = 0;
		    using (IDataReader rd = ExecuteReader("select conferenceID from artigo where conferenceID=@id", parameters))
		    {
			    if (rd.Read())
			    {
				    key = rd.GetInt32(0);
			    }

		    }

		    return cm.Read(key);
	    }

	    protected override string SelectAllCommandText => throw new NotImplementedException();

        protected override string SelectCommandText => throw new NotImplementedException();

        protected override string UpdateCommandText => throw new NotImplementedException();

        protected override CommandType UpdateCommandType => throw new NotImplementedException();

		protected override string DeleteCommandText => throw new NotImplementedException();

        protected override string InsertCommandText => throw new NotImplementedException();

        protected override CommandType InsertCommandType => throw new NotImplementedException();

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
    }
}
