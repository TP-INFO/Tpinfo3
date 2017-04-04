using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tpinfo3
{
    class Program
    {
        static int i, j;
        static void Main(string[] args)
        {


            RemplirTableau();
        }




        /// <summary>
        /// Méthode remplissage petites étoiles
        /// </summary>
        public static void RemplirTableau()
        {
            //déclaration matrice
            char[,] tab = new char[20, 20];

            for (i = 0; i < 20; i++)
            {
                for (j = 0; j < 20; j++)
                {
                    for (int k = 0; k < 15; k++)
                    {
                        /*lignes de 0 à 15*/
                        tab[0, k] = '*';
                        tab[1, k] = '*';
                        tab[2, k] = '*';
                        tab[3, k] = '*';
                    }


                    for (int k = 0; k < 20; k++)
                    {
                        /* colonnes de 0 à 20*/
                        tab[k, 0] = '*';
                        tab[k, 1] = '*';
                        tab[k, 2] = '*';
                        tab[k, 3] = '*';
                    }

                    for (int k = 4; k < 11; k++)
                    {
                        tab[8, k] = '*';
                        tab[9, k] = '*';
                        tab[10, k] = '*';
                        tab[11, k] = '*';
                    }

                    Console.Write("{0} ", tab[i, j]);
                }
                {
                    // !!!!!!!!!!!!!!!!!!!!!!!!!
                    Console.WriteLine();
                }

            }
        }
    }
}

