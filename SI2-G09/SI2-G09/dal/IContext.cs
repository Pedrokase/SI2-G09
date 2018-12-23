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
using System.Data.SqlClient;
using DAL.concrete;
using SI2_G09.concrete;

namespace DAL
{
    interface IContext: IDisposable
    {
        void Open();
        SqlCommand createCommand();
        void EnlistTransaction();

        AutorRepository Autores { get; }
        ArtigoRepository Artigos { get; }
        AutorArtigoRepository AutorArtigos { get; }
        ConferenciaRepository Conferencias { get; }
        ConferenciaUtilizadorRepository ConferenciaUtilizadores { get; }
        FicheiroPDFRepository FicheirosPDF { get; }
        InstituicaoRepository Instituicoes { get; }
        RevisorRepository Revisores { get; }
        RevisorArtigoRepository RevisorArtigos { get; }
        UtilizadorRepository Utilizadores { get; }
        UtilizadorInstituicaoRepository UtilizadorInstituicoes { get; }
    }
}
