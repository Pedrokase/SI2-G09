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
using System.Data.SqlClient;
using DAL.concrete;

namespace DAL
{
    interface IContext: IDisposable
    {
        void Open();
        SqlCommand createCommand();
        void EnlistTransaction();

        CountryRepository Countries { get; }
        CourseRepository Courses { get; }
        StudentRepository Students { get; }

    }
}
