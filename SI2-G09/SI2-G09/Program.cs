using DAL.concrete;
using SI2_G09.concrete;
using SI2_G09.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI2_G09
{
	class Program
	{
        public static string connectionString = "Server=RICARDO;Database=SI2_T1;User Id=sa; Password=1234";

        static void Main(string[] args)
		{
            //TODO pool e outros
            //string connectionString = "Server=192.168.33.102;Database=SI2_T1;User Id=sisu; Password=#_su!si2";
             bool nb = false;
            if (nb)
            {
                using (Context ctx = new Context(connectionString))
                {
                    ConferenciaMapper m = new ConferenciaMapper(ctx);
                    Conferencia c = new Conferencia();
                    c.Id = 1;
                    c.Nome = "teste";
                    RevisorMapper r = new RevisorMapper(ctx);
                    
                    NBench.Bench(() => ctx.Autores.FindAll(), "select * from autor"); // 6400
                    NBench.Bench(() => m.UpdateNotaConferencia(c), "Update Nome Conferencia"); // 2016
                    string s = Console.ReadLine();
                }
            }
            else
            {
                App.Instance.Run();
            }
            //alinea f)
            /* using (Context ctx = new Context(connectionString))
             {
                 Console.WriteLine("FindAll");
                 foreach (var conferencia in ctx.Conferencias.FindAll())
                 {
                     Console.WriteLine("Conferencia: {0}-{1}", conferencia.Id, conferencia.Nome);
                 }

                 ConferenciaMapper conferenciaMap = new ConferenciaMapper(ctx);
                 int id = 1;
                 //Ler a conferencia com id = 1, guardando essa em c
                 Conferencia c = conferenciaMap.Read(id);
                 Console.WriteLine("Percentagem Conferencia: {0}", conferenciaMap.GetAcceptedSubmissionsPercentage(c));
                 Console.WriteLine("Antes: Conferencia: {0}-{1}", c.Id, c.Nome);
                 //Alterar o Nome de c
                 c.Nome = "nome alterado";
                 //Fazer update ao c que tem o nome alterado
                 conferenciaMap.Update(c);
                 Console.WriteLine("Depois: Conferencia: {0}-{1}", c.Id, c.Nome);
             }

             //Alinea g) para revisor
             using (Context ctx = new Context(connectionString))
             {

                 UtilizadorMapper utilizadorMap = new UtilizadorMapper(ctx);
                 RevisorMapper revisorMapper = new RevisorMapper(ctx);

                 Console.WriteLine("FindAll Utilizadores");
                 foreach (var utilizador in ctx.Utilizadores.FindAll())
                 {
                     Console.WriteLine("Utilizador: {0}-{1}", utilizador.ID, utilizador.Email);
                 }

                 int id = 1;
                 //Ler o utilizador com id = 1, guardando essa em c
                 Utilizador c = utilizadorMap.Read(id);
                 Console.WriteLine("Utilizador que vai ficar revisor: {0}-{1}", c.ID, c.Email);

                 Console.WriteLine("FindAll Revisores");
                 foreach (var revisor in ctx.Revisores.FindAll())
                 {
                     Console.WriteLine("Revisor: {0}", revisor.UserID.ID);
                 }
                 Revisor r = new Revisor();
                 //Inserir um Utilizador com id=1 em Revisor
                 //r.ID = 1;
                 r.UserID = c;
                 r = revisorMapper.Create(r);
                 Console.WriteLine("FindAll Revisores");
                 foreach (var revisor in ctx.Revisores.FindAll())
                 {
                     Console.WriteLine("Revisor: {0}", revisor.UserID.ID);
                 }
             }

             //Alinea g) para autor
             using (Context ctx = new Context(connectionString))
             {

                 UtilizadorMapper utilizadorMap = new UtilizadorMapper(ctx);
                 AutorMapper autorMapper = new AutorMapper(ctx);

                 Console.WriteLine("FindAll Utilizadores");
                 foreach (var utilizador in ctx.Utilizadores.FindAll())
                 {
                     Console.WriteLine("Utilizador: {0}-{1}", utilizador.ID, utilizador.Email);
                 }

                 int id = 1;
                 //Ler o utilizador com id = 1, guardando essa em c
                 Utilizador c = utilizadorMap.Read(id);
                 Console.WriteLine("Utilizador que vai ficar revisor: {0}-{1}", c.ID, c.Email);

                 Console.WriteLine("FindAll Autores");
                 foreach (var autor in ctx.Autores.FindAll())
                 {
                     Console.WriteLine("Autor: {0}", autor.UserID.ID);
                 }
                 Autor r = new Autor();
                 //Inserir um Utilizador com id=1 em Revisor
                 r.UserID = c;
                 r = autorMapper.Create(r);
                 Console.WriteLine("FindAll Autor Após a criação");
                 foreach (var autor in ctx.Autores.FindAll())
                 {
                     Console.WriteLine("Autor: {0}", autor.UserID.ID);
                 }

             }

             // alinea h)
             using (Context ctx = new Context(connectionString))
             {
                 RevisorMapper revisorMap = new RevisorMapper(ctx);
                 List<Revisor> r = revisorMap.ReadAll();
                 foreach (Revisor re in r)
                 {
                     Console.WriteLine("Revisor: {0}", re.UserID.ID);
                 }
                 List<object> result = revisorMap.CompatibleReviewers(1, 1);
                 foreach (object id in result)
                 {
                     Console.WriteLine("Revisores Compativeis: {0}", id);
                 }
             }

             // alinea i)
             using (Context ctx = new Context(connectionString))
             {
                 RevisorArtigoMapper revisorartigoMap = new RevisorArtigoMapper(ctx);
                 RevisorMapper revisorMapper = new RevisorMapper(ctx);
                 ArtigoMapper artigoMapper = new ArtigoMapper(ctx);
                 ConferenciaMapper conferenciaMapper = new ConferenciaMapper(ctx);
                 RevisorArtigo newRevisorArtigo = new RevisorArtigo();

                 Conferencia c = conferenciaMapper.Read(1);
                 Revisor r = revisorMapper.Read(6);
                 Artigo a = artigoMapper.Read(1);

                 newRevisorArtigo.ArtigoRevisto = a;
                 newRevisorArtigo.Revisor = r;
                 newRevisorArtigo.Nota = 100;
                 newRevisorArtigo.Texto = "nova revisão";
                 RevisorArtigo result = revisorartigoMap.Create(newRevisorArtigo);
                 Console.WriteLine("Revisor {0} adicionado ao artigo {1} da conferencia {2}", result.Revisor.UserID.ID, result.ArtigoRevisto.ID, result.ArtigoRevisto.Conferencia.Id);

             }

             //alinea j)
             using (Context ctx = new Context(connectionString))
             {
                 RevisorArtigoMapper revisorArtigoMapper = new RevisorArtigoMapper(ctx);
                 ArtigoMapper artigoMapper = new ArtigoMapper(ctx);
                 RevisorMapper revisorMapper = new RevisorMapper(ctx);
                 RevisorArtigo e = new RevisorArtigo();
                 Artigo a = artigoMapper.Read(1);
                 Revisor r = revisorMapper.Read(5);
                 e.ArtigoRevisto = a;
                 e.Nota = 10;
                 e.Texto = "Teste";
                 e.Revisor = r;

                 RevisorArtigo result = revisorArtigoMapper.Update(e);
                 Console.WriteLine("Alteração do artigo ID = {0} para o texto {1}", result.ArtigoRevisto.ID, result.Texto);


             }

             //k)
             using (Context ctx = new Context(connectionString))
             {
                 RevisorArtigoMapper ra = new RevisorArtigoMapper(ctx);
                 ConferenciaMapper cm = new ConferenciaMapper(ctx);
                 IEnumerable<Conferencia> conf = ctx.Conferencias.FindAll();
                 IEnumerable<Utilizador> ut = ctx.Utilizadores.FindAll();
                 IEnumerable<Artigo> art = ctx.Artigos.FindAll();
                 ctx.RevisorArtigos.FindAll();
                 Console.WriteLine(cm.GetAcceptedSubmissionsPercentage(cm.Read(1)));
             }

             //l)
             using (Context ctx = new Context(connectionString))
             {
                 ArtigoMapper artigoMap = new ArtigoMapper(ctx);
                 Artigo a = new Artigo();
                 a.ID = 1;
                 a.Estado = "Revisao";
                 a.DataSubmetido = DateTime.Parse("2018-12-01");
                 Conferencia c = new Conferencia();
                 c.Id = 3;
                 c.DataSubmissao = DateTime.Parse("2018-03-01");
                 a.Conferencia = c;
                 Console.WriteLine("Estado do Artigo atual - {0}", a.Estado);
                 Artigo result = artigoMap.ChangeSubmission(a, DateTime.Parse("2018-03-01"));
             }

             */

        }

        class App
        {
            private enum Option
            {
                Unknown = -1,
                Exit,
                UpdateNotaConferencia,
                UtilizadorToAutor,
                listCompatibleReviewers,
                addReviewerToArticle,
                RegistoRevisao,
                AcceptSubmissionRate,
                UpdateState

            }
            private static App __instance;
            private App()
            {
                __dbMethods = new Dictionary<Option, DBMethod>();
                __dbMethods.Add(Option.UpdateNotaConferencia, UpdateNotaConferencia);
                __dbMethods.Add(Option.UtilizadorToAutor, UtilizadorToAutor);
                __dbMethods.Add(Option.listCompatibleReviewers, listCompatibleReviewers);
                __dbMethods.Add(Option.addReviewerToArticle, addReviewerToArticle);
                __dbMethods.Add(Option.RegistoRevisao, RegistoRevisao);
                __dbMethods.Add(Option.AcceptSubmissionRate, AcceptSubmissionRate);
                __dbMethods.Add(Option.UpdateState, UpdateState);

            }
            public static App Instance
            {
                get
                {
                    if (__instance == null)
                        __instance = new App();
                    return __instance;
                }
                private set { }
            }

            private Option DisplayMenu()
            {
                Option option = Option.Unknown;
                try
                {
                    Console.WriteLine("Course management");
                    Console.WriteLine();
                    Console.WriteLine("1. UpdateNotaConferencia");
                    Console.WriteLine("2. UtilizadorToAutor");
                    Console.WriteLine("3. listCompatibleReviewers");
                    Console.WriteLine("4. addReviewerToArticle");
                    Console.WriteLine("5. RegistoRevisao");
                    Console.WriteLine("6. AcceptSubmissionRate");
                    Console.WriteLine("7. UpdateState");
                    Console.WriteLine("0. Exit");
                    var result = Console.ReadLine();
                    option = (Option)Enum.Parse(typeof(Option), result);
                }
                catch (ArgumentException ex)
                {
                    //nothing to do. User press select no option and press enter.
                }

                return option;

            }
            private delegate void DBMethod();
            private System.Collections.Generic.Dictionary<Option, DBMethod> __dbMethods;
            public string ConnectionString
            {
                get;
                set;
            }

            public void Run()
            {
                Option userInput = Option.Unknown;
                do
                {
                    Console.Clear();
                    userInput = DisplayMenu();
                    Console.Clear();
                    try
                    {
                        __dbMethods[userInput]();
                        Console.ReadKey();
                    }
                    catch (KeyNotFoundException ex)
                    {
                        //Nothing to do. The option was not a valid one. Read another.
                    }

                } while (userInput != Option.Exit);
            }

            private void UpdateNotaConferencia()
            {
                //TODO: Implement
                using (Context ctx = new Context(connectionString))
                {
                    Console.WriteLine("FindAll");
                    foreach (var conferencia in ctx.Conferencias.FindAll())
                    {
                        Console.WriteLine("Conferencia: {0}-{1}", conferencia.Id, conferencia.Nome);
                    }

                    ConferenciaMapper conferenciaMap = new ConferenciaMapper(ctx);

                    Console.WriteLine("(1)Insira ConferenceID");
                    int id = Convert.ToInt32(Console.ReadLine());
                    //Ler a conferencia com id = 1, guardando essa em c
                    Conferencia c = conferenciaMap.Read(id);
                    Console.WriteLine("Antes: Conferencia: {0}-{1}", c.Id, c.Nome);
                    //Alterar o Nome de c
                    Console.WriteLine("(nome alterado)Insira nome");
                    string s = Console.ReadLine();
                    c.Nome = s;
                    //Fazer update ao c que tem o nome alterado
                    conferenciaMap.Update(c);
                    Console.WriteLine("Depois: Conferencia: {0}-{1}", c.Id, c.Nome);
                }
                
            }
            private void UtilizadorToAutor()
            {
                using (Context ctx = new Context(connectionString))
                {

                    UtilizadorMapper utilizadorMap = new UtilizadorMapper(ctx);
                    AutorMapper autorMapper = new AutorMapper(ctx);

                    Console.WriteLine("FindAll Utilizadores");
                    foreach (var utilizador in ctx.Utilizadores.FindAll())
                    {
                        Console.WriteLine("Utilizador: {0}-{1}", utilizador.ID, utilizador.Email);
                    }

                    Console.WriteLine("(1)Insira UserID");
                    int id = Convert.ToInt32(Console.ReadLine());
                    
                    //Ler o utilizador com id = 1, guardando essa em c
                    Utilizador c = utilizadorMap.Read(id);
                    Console.WriteLine("Utilizador que vai ficar revisor: {0}-{1}", c.ID, c.Email);

                    Console.WriteLine("FindAll Autores");
                    foreach (var autor in ctx.Autores.FindAll())
                    {
                        Console.WriteLine("Autor: {0}", autor.UserID.ID);
                    }
                    Autor r = new Autor();
                    //Inserir um Utilizador com id=1 em Revisor
                    r.UserID = c;
                    r = autorMapper.Create(r);
                    Console.WriteLine("FindAll Autor Após a criação");
                    foreach (var autor in ctx.Autores.FindAll())
                    {
                        Console.WriteLine("Autor: {0}", autor.UserID.ID);
                    }

                }
            }
            private void listCompatibleReviewers()
            {
                //TODO: Implement
                using (Context ctx = new Context(connectionString))
                {
                    RevisorMapper revisorMap = new RevisorMapper(ctx);
                    List<Revisor> r = revisorMap.ReadAll();
                    foreach (Revisor re in r)
                    {
                        Console.WriteLine("Revisor: {0}", re.UserID.ID);
                    }

                    Console.WriteLine("(1)Insira ConferenceID");
                    int id = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("(1)Insira ArticleID");
                    int id2 = Convert.ToInt32(Console.ReadLine());
                    List<object> result = revisorMap.CompatibleReviewers(id, id2);
                    foreach (object id3 in result)
                    {
                        Console.WriteLine("Revisores Compativeis: {0}", id3);
                    }
                }
            }
            private void addReviewerToArticle()
            {
                //TODO: Implement
                using (Context ctx = new Context(connectionString))
                {
                    RevisorArtigoMapper revisorartigoMap = new RevisorArtigoMapper(ctx);
                    RevisorMapper revisorMapper = new RevisorMapper(ctx);
                    ArtigoMapper artigoMapper = new ArtigoMapper(ctx);
                    ConferenciaMapper conferenciaMapper = new ConferenciaMapper(ctx);
                    RevisorArtigo newRevisorArtigo = new RevisorArtigo();
                    Console.WriteLine("(1)Insira ConferenceID");
                    int id = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("(1)Insira ArtigoID");
                    int id2 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("(6)Insira RevisorID");
                    int id3 = Convert.ToInt32(Console.ReadLine());
                    Conferencia c = conferenciaMapper.Read(id);
                    Revisor r = revisorMapper.Read(id3);
                    Artigo a = artigoMapper.Read(id2);

                    newRevisorArtigo.ArtigoRevisto = a;
                    newRevisorArtigo.Revisor = r;
                    Console.WriteLine("(100)Insira nota");
                    int n = Convert.ToInt32(Console.ReadLine());
                    newRevisorArtigo.Nota = n;
                    Console.WriteLine("(nova revisao)Insira texto");
                    string s = Console.ReadLine();
                    newRevisorArtigo.Texto = s;
                    RevisorArtigo result = revisorartigoMap.Create(newRevisorArtigo);
                    Console.WriteLine("Revisor {0} adicionado ao artigo {1} da conferencia {2}", result.Revisor.UserID.ID, result.ArtigoRevisto.ID, result.ArtigoRevisto.Conferencia.Id);

                }
            }
            private void RegistoRevisao()
            {
                //TODO: Implement
                using (Context ctx = new Context(connectionString))
                {
                    RevisorArtigoMapper revisorArtigoMapper = new RevisorArtigoMapper(ctx);
                    ArtigoMapper artigoMapper = new ArtigoMapper(ctx);
                    RevisorMapper revisorMapper = new RevisorMapper(ctx);
                    RevisorArtigo e = new RevisorArtigo();

                    Console.WriteLine("(1)Insira ArtigoID");
                    int id1 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("(5)Insira RevisorID");
                    int id2 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("(10)Insira nota");
                    int n = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("(teste)Insira texto");
                    string s = Console.ReadLine();
                    Artigo a = artigoMapper.Read(id1);
                    Revisor r = revisorMapper.Read(id2);
                    e.ArtigoRevisto = a;
                    e.Nota = n;
                    e.Texto = s;
                    e.Revisor = r;

                    RevisorArtigo result = revisorArtigoMapper.Update(e);
                    Console.WriteLine("Alteração do artigo ID = {0} para o texto {1}", result.ArtigoRevisto.ID, result.Texto);


                }
            }
            private void AcceptSubmissionRate()
            {
                //TODO: Implement
                using (Context ctx = new Context(connectionString))
                {
                    RevisorArtigoMapper ra = new RevisorArtigoMapper(ctx);
                    ConferenciaMapper cm = new ConferenciaMapper(ctx);
                    IEnumerable<Conferencia> conf = ctx.Conferencias.FindAll();
                    IEnumerable<Utilizador> ut = ctx.Utilizadores.FindAll();
                    IEnumerable<Artigo> art = ctx.Artigos.FindAll();
                    ctx.RevisorArtigos.FindAll();

                    Console.WriteLine("(1)Insira ConferenciaID");
                    int n = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine(cm.GetAcceptedSubmissionsPercentage(cm.Read(n)));
                }
            }
            private void UpdateState() {
                using (Context ctx = new Context(connectionString))
                {
                    Console.WriteLine("(1)Insira ArtigoID");
                    int n = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("(1)Insira ConferenciaID");
                    int n1 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("(2018-03-12)Insira data corte");
                    string s = Console.ReadLine();
                    ArtigoMapper artigoMap = new ArtigoMapper(ctx);
                    Artigo a = new Artigo();
                    a.ID = n;
                    a.Estado = "Revisao";
                    a.DataSubmetido = DateTime.Parse("2018-12-01");
                    Conferencia c = new Conferencia();
                    c.Id = n1;
                    c.DataSubmissao = DateTime.Parse("2018-03-01");
                    a.Conferencia = c;
                    Console.WriteLine("Estado do Artigo atual - {0}", a.Estado);
                    Artigo result = artigoMap.ChangeSubmission(a, DateTime.Parse(s));

                    Console.WriteLine("Estado do Artigo atual - {0}", result.Estado);
                }
            }
        }
       
        
    }
}
