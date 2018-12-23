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

		static void Main(string[] args)
		{
			//TODO pool e outros
			string connectionString = "Server=192.168.33.102;Database=SI2_T1;User Id=sisu; Password=#_su!si2";

            //alinea f)
			using (Context ctx = new Context(connectionString))
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
                    Console.WriteLine("Revisor: {0}-{1}", revisor.UserID.ID, revisor.UserID.Email);
                }
                Revisor r = new Revisor();
                //Inserir um Utilizador com id=1 em Revisor
                r.ID = 1;
                r.UserID = c;
                r = revisorMapper.Create(r);
                Console.WriteLine("FindAll Revisores");
                foreach (var revisor in ctx.Revisores.FindAll())
                {
                    Console.WriteLine("Revisor: {0}-{1}", revisor.UserID.ID, revisor.UserID.Email);
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
                    Console.WriteLine("Autor: {0}-{1}", autor.UserID.ID, autor.UserID.Email);
                }
                Autor r = new Autor();
                //Inserir um Utilizador com id=1 em Revisor
                r.ID = 1;
                r.UserID = c;
                r = autorMapper.Create(r);
                Console.WriteLine("FindAll Autor Após a criação");
                foreach (var autor in ctx.Autores.FindAll())
                {
                    Console.WriteLine("Revisor: {0}-{1}", autor.UserID.ID, autor.UserID.Email);
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
                RevisorArtigo result = revisorartigoMap.addReviewerToArticle(1, 1, 6);
                Console.WriteLine("Revisor {0} adicionado ao artigo {1} da conferencia {2}", result.Revisor.ID, result.ArtigoRevisto.ID, result.ArtigoRevisto.Conferencia.Id);

            }



        }
	}
}
