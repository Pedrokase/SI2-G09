using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFSI2_G09
{
    class Program
    {
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
                Console.WriteLine("UpdateNotaConferencia()");
                Console.WriteLine("(1)Insira ConferenceID");
                int i = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("(80)Insira nota");
                int n = Convert.ToInt32(Console.ReadLine());
                using (SI2_T1Entities db = new SI2_T1Entities())
                {
                    Console.WriteLine("Conferencia Atual");
                    Conferencia c1 = db.Conferencia.Where((x) => x.ID == i).FirstOrDefault();
                    Console.WriteLine("Conferencia: {0} tem nota {1}", c1.ID, c1.nota_minima);
                    db.UpdateNotaConferencia(i, n);

                }
                using (SI2_T1Entities db = new SI2_T1Entities())
                {
                    Console.WriteLine("Conferencia Atualizada");
                    Conferencia c2 = db.Conferencia.Where((x) => x.ID == i).FirstOrDefault();
                    Console.WriteLine("Conferencia: {0} tem nota {1}", c2.ID, c2.nota_minima);
                }
            }
            private void UtilizadorToAutor()
            {
                //TODO: Implement
                Console.WriteLine("UtilizadorToAutor()");
                Console.WriteLine("(utilizador5@isel.pt)Insira email");
                string e = Console.ReadLine();
                using (SI2_T1Entities db = new SI2_T1Entities())
                {
                    Console.WriteLine("Autores na DataBase");
                    var a = db.Autor.ToList();
                    foreach (var res in a)
                    {
                        Console.WriteLine("Utilizador: {0} tem email {1}", res.userID, res.Utilizador.email);
                    }
                    db.UtilizadorToAutor(e);
                }
                using (SI2_T1Entities db = new SI2_T1Entities())
                {
                    Console.WriteLine("Novo Autor");
                    Autor a = db.Autor.Where((x) => x.Utilizador.email == e).FirstOrDefault();
                    Console.WriteLine("Utilizador: {0} tem email {1}", a.userID, a.Utilizador.email);
                }

            }
            private void listCompatibleReviewers()
            {
                //TODO: Implement
                Console.WriteLine("listCompatibleReviewers()");
                Console.WriteLine("(1)Insira ConferenceID");
                int i1 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("(1)Insira ArticleID");
                int i2 = Convert.ToInt32(Console.ReadLine());
                using (SI2_T1Entities db = new SI2_T1Entities())
                {
                    var l = db.listCompatibleReviewers(i1, i2).ToList();
                    foreach (var res in l)
                    {
                        Console.WriteLine("Revisores Compativeis: {0}", res.userID);
                    }
                }
            }
            private void addReviewerToArticle()
            {
                //TODO: Implement
                Console.WriteLine("addReviewerToArticle()");
                Console.WriteLine("(1)Insira ConferenceID");
                int i1 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("(1)Insira ArticleID");
                int i2 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("(6)Insira ReviewerID");
                int i3 = Convert.ToInt32(Console.ReadLine());
                using (SI2_T1Entities db = new SI2_T1Entities())
                {
                    Console.WriteLine("Revisor_Artigo na DataBase");
                    var a = db.Revisor_Artigo.ToList();
                    foreach (var res in a)
                    {
                        Console.WriteLine("Revisor_artigo: UserID-{0} | articleID-{1} | conferenceID-{2}", res.userID, res.ID, res.conferenceID);
                    }
                    db.addReviewerToArticle(i1, i2, i3);
                }
                using (SI2_T1Entities db = new SI2_T1Entities())
                {
                    Console.WriteLine("Novo Revisor_Artigo");
                    Revisor_Artigo a = db.Revisor_Artigo.Where((x) => x.userID == i3 && x.ID == i2 && x.conferenceID == i1).FirstOrDefault();
                    Console.WriteLine("Revisor_artigo: UserID-{0} | articleID-{1} | conferenceID-{2}", a.userID, a.ID, a.conferenceID);
                }
            }
            private void RegistoRevisao()
            {
                //TODO: Implement
                Console.WriteLine("RegistoRevisao()");
                Console.WriteLine("(5)Insira UserID");
                int i1 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("(1)Insira ArticleID");
                int i2 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("(1)Insira ConferenceID");
                int i3 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("(95)Insira nota");
                int i4 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("(good)Insira texto");
                string s = Console.ReadLine();
                using (SI2_T1Entities db = new SI2_T1Entities())
                {
                    Console.WriteLine("Revisor_Artigo Atual");
                    Revisor_Artigo a = db.Revisor_Artigo.Where((x) => x.userID == i1 && x.ID == i2 && x.conferenceID == i3).FirstOrDefault();
                    Console.WriteLine("Revisor_artigo: UserID-{0} | articleID-{1} | conferenceID-{2} | nota-{3} | texto-{4}", a.userID, a.ID, a.conferenceID, a.nota, a.texto);
                    db.RegistoRevisao(i1, i2, i3, i4, s);

                }
                using (SI2_T1Entities db = new SI2_T1Entities())
                {
                    Console.WriteLine("Revisor_Artigo Atualizado");
                    Revisor_Artigo a = db.Revisor_Artigo.Where((x) => x.userID == i1 && x.ID == i2 && x.conferenceID == i3).FirstOrDefault();
                    Console.WriteLine("Revisor_artigo: UserID-{0} | articleID-{1} | conferenceID-{2} | nota-{3} | texto-{4}", a.userID, a.ID, a.conferenceID, a.nota, a.texto);
                }
            }
            private void AcceptSubmissionRate()
            {
                //TODO: Implement
                Console.WriteLine("AcceptSubmissionRate()");
                Console.WriteLine("(1)Insira ConferenceID");
                int i1 = Convert.ToInt32(Console.ReadLine());
                using (SI2_T1Entities db = new SI2_T1Entities())
                {
                    int prec = db.AcceptSubmissionRate(i1);
                    Console.WriteLine("Percentagem de submissoes aceites da conferencia 1 - {0}", prec);
                }
            }
        }
        static void Main(string[] args)
        {
            bool nb = false;
            if (nb)
            {
                using (SI2_T1Entities db = new SI2_T1Entities())
                {
                    NBench.Bench(() => db.Autor.Where(x => x.userID == 4), "select * from autor where userid=4"); //21248
                    NBench.Bench(() => db.Conferencia.Where(x => x.ID == 1).Select(u => u.nome), "select nome from conferencia where ID=1"); //10624
                    NBench.Bench(() => db.UpdateNotaConferencia(1, 80), "Update Nota Conferencia"); //896
                    NBench.Bench(() => db.listCompatibleReviewers(1, 1), "Compatible Reviewers"); //41760
                    string s = Console.ReadLine();
                }
            }
            else
            {
                App.Instance.Run();
            }
        }

        public static void UpdateState()
        {
            using (SI2_T1Entities db = new SI2_T1Entities())
            {
                Console.WriteLine("(3)Insira UserID");
                int i1 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("(2018-03-01)Insira data");
                string s = Console.ReadLine();
                DateTime? dt = DateTime.Parse(s);
                Conferencia c = db.Conferencia.Where((x) => x.ID == i1).FirstOrDefault();
                if (dt == null)
                {
                    dt = c.data_revisao;
                }
                if (dt >= c.data_submissao)
                {
                    List<Artigo> res = db.Artigo.Where((x) => x.conferenceID == i1 && x.data_submetido >= dt && x.estado != "Aceite").ToList();
                    foreach (Artigo result in res)
                    {
                        Console.WriteLine("Artigo da Conferencia 3 tem estado {0}", result.estado);
                        result.estado = "Rejeitado";
                        db.SaveChanges();
                        Console.WriteLine("Artigo da Conferencia 3 tem estado {0}", result.estado);
                    }
                }
                else
                {
                    Console.WriteLine("Data de Corte inferior à data de submissao!");
                }
            }
        }
    }
}