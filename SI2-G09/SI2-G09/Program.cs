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
            //string connectionString = "Server=RICARDO;Database=SI2_T1;User Id=sa; Password=1234";
            
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



        }
	}
}
