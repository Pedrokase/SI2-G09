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
using System.Collections.Generic;


namespace DAL
{
    interface IRepository<T>
    {
        IEnumerable<T> FindAll();
        IEnumerable<T> Find(System.Func<T, bool> criteria);
    }
}
