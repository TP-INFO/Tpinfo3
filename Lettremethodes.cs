using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPinfo3
{
    class Lettremethodes
    {
        static public string Messageaide = " Aide : entrer une des lettre suivante M, N, C, L, B, F ";
        public static string Messagedeversion = "version v1.0 copy right @2017  :p "; 
        public static void afficheM()
        {
            char[,] tableau = new char[20, 20];  // cette methode permet d'afficher la lettre M


            for (int i = 0; i < 20; i++)
            {
                tableau[i, 0] = '*';             // je remplit les deux colone opposé de la lettre M
            }

            for (int i = 0; i < 20; i++)
            {
                tableau[i, 19] = '*';
            }


            for (int i = 1; i < 10; i++)
            {                                        // je rempli les deux digonale de la lettre M
                tableau[i, i] = '*';
            }


            for (int i = 9; i != 0; i--)
            {
                tableau[i, 20 - i - 1] = '*';

            }

            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    Console.Write("{0} ", tableau[i, j]);
                }
                Console.WriteLine();

            }
        }
        public static void afficheN()          // lettre N
        {
            char[,] tableau = new char[20, 20];


            for (int i = 0; i < 20; i++)
            {
                tableau[i, 0] = '*';
            }

            for (int i = 0; i < 20; i++)
            {
                tableau[i, 19] = '*';
            }


            for (int i = 1; i < 20; i++)
            {
                tableau[i, i] = '*';
            }

            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    Console.Write("{0} ", tableau[i, j]);
                }
                Console.WriteLine();

            }
        }
        public static void afficheC()    // lettre C 
        {
            char[,] tableau = new char[20, 20];


            for (int i = 1; i < 19; i++)
            {
                tableau[i, 0] = '*';
            }

            for (int j = 1; j < 10; j++)
            {
                tableau[0, j] = '*';
            }
            for (int j = 1; j < 10; j++)
            {
                tableau[19, j] = '*';
            }
            tableau[0, 0] = '/';
            tableau[19, 0] = '\\';
        
        for (int i = 0; i< 20; i++)
            {
                for (int j = 0; j< 20; j++)
                {
                    Console.Write("{0} ", tableau[i, j]);
                }
    Console.WriteLine();

            }
        }

        public static void AfficheL()   // LETTRE L 
        {
            char[,] tableau = new char[20, 20];


            for (int i = 0; i < 20; i++)
            {
                tableau[i, 0] = '*';
            }

            for (int j = 0; j < 9; j++)
            {
                tableau[19, j] = '*';
            }


            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    Console.Write("{0} ", tableau[i, j]);
                }
                Console.WriteLine();

            }
        }
        public static void AfficheB() // LETTRE B 
        {

            char[,] tableau = new char[20, 20];

            for (int i = 0; i < 20; i++)
            {
                tableau[i, 0] = '*';
            }

            for (int j = 0; j < 9; j++)
            {
                tableau[0, j] = '*';
            }
            for (int i = 0; i < 9; i++)
            {
                tableau[i, 8] = '*';
            }
            for (int j = 0; j < 9; j++)
            {
                tableau[8, j] = '*';
            }
            for (int j = 0; j < 9; j++)
            {
                tableau[19, j] = '*';
            }
            for (int i = 9; i < 20; i++)
            {
                tableau[i, 9] = '*';
            }

            tableau[9, 9] = '\\';

            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    Console.Write("{0} ", tableau[i, j]);
                }
                Console.WriteLine();

            }
        }
        public static void afficheF() // LETTRE F 
        {

            char[,] tableau = new char[20, 20];


            for (int i = 0; i < 20; i++)
            {
                tableau[i, 0] = '*';
            }

            for (int j = 0; j < 8; j++)
            {
                tableau[0, j] = '*';

            }
            for (int j = 0; j < 8; j++)
            {
                tableau[8, j] = '*';
            }
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    Console.Write("{0} ", tableau[i, j]);
                }
                Console.WriteLine();

            }
        } 
            public static void thehelp(string leMessageaide)
        {
            Console.WriteLine(Messageaide);
        } 
        public static void Laversion(string leMessagevesion)
        {
            Console.WriteLine(Messagedeversion);
        } 

        }
    }

 
    



