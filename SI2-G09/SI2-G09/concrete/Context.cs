/*
*
*   ISEL-ADEETC-SI2
*   ND 2014-2017
*
*   Material didático para apoio 
*   à unidade curricular de 
*   Sistemas de Informação II
*
*   O código pode não ser completo.
**/
using System;
using System.Transactions;
using System.Data;
using System.Data.SqlClient;
using SI2_G09.concrete;

namespace DAL.concrete
{
    class Context : IContext
    {
        private string connectionString;
        private SqlConnection con = null;

        private ArtigoRepository _artigoRepository;
        private AutorRepository _autorRepository;
        private AutorArtigoRepository _autorArtigoRepository;
        private ConferenciaRepository _conferenciaRepository;
        private ConferenciaUtilizadorRepository _conferenciaUtilizadorRepository;
        private FicheiroPDFRepository _ficheiroPDFRepository;
        private InstituicaoRepository _instituicaoRepository;
        private RevisorRepository _revisorRepository;
        private RevisorArtigoRepository _revisorArtigoRepository;
        private UtilizadorRepository _utilizadorRepository;
        private UtilizadorInstituicaoRepository _utilizadorInstituicaoRepository;


        public Context(string cs)
        {
            connectionString = cs;
            _artigoRepository = new ArtigoRepository(this);
            _autorRepository = new AutorRepository(this);
            _autorArtigoRepository = new AutorArtigoRepository(this);
            _conferenciaRepository = new ConferenciaRepository(this);
            _conferenciaUtilizadorRepository = new ConferenciaUtilizadorRepository(this);
            _ficheiroPDFRepository = new FicheiroPDFRepository(this);
            _instituicaoRepository = new InstituicaoRepository(this);
            _revisorRepository = new RevisorRepository(this);
            _revisorArtigoRepository = new RevisorArtigoRepository(this);
            _utilizadorRepository = new UtilizadorRepository(this);
            _utilizadorInstituicaoRepository = new UtilizadorInstituicaoRepository(this);
        }

        public void Open()
        {
            if (con == null)
            {
                con = new SqlConnection(connectionString);

            }
            if (con.State != ConnectionState.Open)
                con.Open();
        }

        public SqlCommand createCommand()
        {
            Open();
            SqlCommand cmd = con.CreateCommand();
            return cmd;
        }
        public void Dispose()
        {
            if (con != null)
            {
                con.Dispose();
                con = null;
            }

        }

        public void EnlistTransaction()
        {
            if (con != null)
            {
                con.EnlistTransaction(Transaction.Current);
            }
        }

        public AutorRepository Autores
        {
            get
            {
                return _autorRepository;
            }
        }

        public ArtigoRepository Artigos
        {
            get
            {
                return _artigoRepository;
            }
        }

        public AutorArtigoRepository AutorArtigos
        {
            get
            {
                return _autorArtigoRepository;
            }
        }

        public ConferenciaRepository Conferencias
        {
            get
            {
                return _conferenciaRepository;
            }
        }

        public ConferenciaUtilizadorRepository ConferenciaUtilizadores
        {
            get
            {
                return _conferenciaUtilizadorRepository;
            }
        }

        public FicheiroPDFRepository FicheirosPDF
        {
            get
            {
                return _ficheiroPDFRepository;
            }
        }

        public InstituicaoRepository Instituicoes 
        {
            get
            {
                return _instituicaoRepository;
            }
        }

        public RevisorRepository Revisores 
        {
            get
            {
                return _revisorRepository;
            }
        }

        public RevisorArtigoRepository RevisorArtigos
        {
            get
            {
                return _revisorArtigoRepository;
            }
        }

        public UtilizadorRepository Utilizadores
        {
            get
            {
                return _utilizadorRepository;
            }
        }

        public UtilizadorInstituicaoRepository UtilizadorInstituicoes 
        {
            get
            {
                return _utilizadorInstituicaoRepository;
            }
        }
    }
}
