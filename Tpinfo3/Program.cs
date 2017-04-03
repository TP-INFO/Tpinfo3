using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tpinfo3
{
    class Program
    {
        static void Main(string[] args)
        {
			// évaluation de l'arg avec appel de la méthode
			if(args.Length >= 1)
			{
				char arg = Convert.ToChar(args[0]);
				Print.AfficherPrint(arg);
			}
			else
			{
				Console.WriteLine("tapez une lettre");
			}
			
        }

    }
}


