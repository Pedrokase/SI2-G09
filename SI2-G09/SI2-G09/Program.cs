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
            string connectionString = "Server=192.168.33.102;Database=SI2_T1;User Id=sisu; Password=#_su!si2";

            using (Context ctx = new Context(connectionString))
            {
                Conferencia c = new Conferencia();
                Console.WriteLine("FindAll");
                foreach (var conferencia in ctx.Conferencias.FindAll())
                {
                    Console.WriteLine("Course: {0}-{1}", conferencia.Id, conferencia.Nome);
                }
                //c.Id = 1;
                //ConferenciaMapper conferenciaMap = new ConferenciaMapper(ctx);
                //c = 
            }


        }
	}
}
