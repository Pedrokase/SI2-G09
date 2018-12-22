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

            //Alinea g)
			using (Context ctx = new Context(connectionString))
			{

                Console.WriteLine("FindAll Utilizadores");
				foreach (var utilizador in ctx.Utilizadores.FindAll())
				{
					Console.WriteLine("Utilizador: {0}-{1}", utilizador.ID, utilizador.Email);
				}

				UtilizadorMapper utilizadorMap = new UtilizadorMapper(ctx);
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
                RevisorMapper revisorMapper = new RevisorMapper(ctx);
                //Inserir um Utilizador com id=1 em Revisor
                r.UserID = c;
                r = revisorMapper.Create(r);
                Console.WriteLine("FindAll Revisores");
                foreach (var revisor in ctx.Revisores.FindAll())
                {
                    Console.WriteLine("Revisor: {0}-{1}", revisor.UserID.ID, revisor.UserID.Email);
                }

			}

			#endregion FindAll


		}
	}
}
