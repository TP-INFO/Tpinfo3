using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_03_22_TP3
{
    class Program
    {
        static void Main(string[] args)
        {
            //Déclaration du tableau de char 20x20
            char[,] tab = new char[20, 20];
            //Remplissage 1ère ligne
            for (int i = 0; i < 20; i++)
            {
                tab[0, i] = '#';
            }
            //Remplissage 1ère colonne
            for (int j = 0; j < 20; j++)
            {
                tab[j, 0] = '#';
            }
            //Remplissage dernière ligne
            for (int k = 0; k < 20; k++)
            {
                tab[19, k] = '#';
            }
            //Parcours le tableau pour afficher le 'C'
            for (int l = 0; l < 20; l++)
            {
                for (int m = 0; m < 20; m++)
                {
                    Console.Write(tab[l,m]);
                }
                Console.WriteLine();
            }
        }
    }
}
