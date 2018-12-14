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

namespace DAL.concrete
{
    class Context: IContext
    {
        private string connectionString;
        private SqlConnection con = null;

        private CountryRepository _countryRepository;
        private CourseRepository _courseRepository;
        private StudentRepository _studentRepository;

      
        public Context(string cs)
        {
            connectionString = cs;
            _countryRepository = new CountryRepository(this);
            _courseRepository = new CourseRepository(this);
            _studentRepository = new StudentRepository(this);
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

        public CountryRepository Countries
        {
            get
            {
                return _countryRepository;
            }
        }

        public CourseRepository Courses
        {
            get
            {
                return _courseRepository;
            }
        }

        public StudentRepository Students
        {
            get
            {
                return _studentRepository;
            }
        }


    }
}
