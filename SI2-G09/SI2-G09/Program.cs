using DAL.concrete;
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
           string connectionString = @"Data Source=.;Initial Catalog=SI2;"
            + "Integrated Security=true;Max Pool Size=10";

            using (Context ctx = new Context(connectionString))
            {

            }


        }
	}
}
