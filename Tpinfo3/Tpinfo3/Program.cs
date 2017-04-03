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
            AfficherLettreH();

        }

        /// <summary>
        /// Implémentation de la méthode.
        /// </summary>
        public static void AfficherLettreH()
        {
            char[,] LettreH = new char[20, 20];

            // Configuration de la lettre H.
            for (int i = 5; i <= 15; i++)
            {
                LettreH[i, 5] = '#';
            }
            for (int j = 5; j <= 15; j++)
            {
                LettreH[j,15] = '#';
            }
            for (int k = 5; k <= 15; k++)
            {
                LettreH[10,k] = '#';
            }

            // Affichage de la lettre H
            for (int l = 0; l < LettreH.GetLength(0); l++)
            {
                for (int m = 0; m < LettreH.GetLength(1); m++)
                {
                    Console.Write(LettreH[l,m]);
                }
                Console.WriteLine();
            }
          
            
        }
    }
}
