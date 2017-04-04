using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPinfo3
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length >= 1)
            {
                switch (args[0])
                {
                    case "M":
                        Lettremethodes.afficheM();
                        break;
                    case "B":
                        Lettremethodes.AfficheB();
                        break;
                    case "C":
                        Lettremethodes.afficheC();
                        break;
                    case "L":
                        Lettremethodes.AfficheL();
                        break;
                    case "N":
                        Lettremethodes.afficheN();
                        break;
                    case "F":
                        Lettremethodes.afficheF();
                        break;
                    case "Help":
                        Lettremethodes.thehelp(Lettremethodes.Messageaide);
                        break;
                    case "version":
                        Lettremethodes.Laversion(Lettremethodes.Messagedeversion);
                        break;
                }
            }
            else
            {
                Console.WriteLine("ce  programme permet de :"); 
                Console.WriteLine("  ");
                Console.WriteLine("--Afficher un message d'aide");
                Console.WriteLine("");
                Console.WriteLine("--Afficher une des lettre = N,B,C,F,L,M");
                Console.WriteLine("");
                Console.WriteLine("--Afficher un message de version ");
                Console.WriteLine("");
                Console.WriteLine("***ce programme  fonctionne seulement en invite de commande*** ");
                Console.WriteLine(""); 
               
            }
        }
    }
}


