using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tpinfo3
{
    class Program
    {
        protected static int origRow;
        protected static int origCol;

        static void Main(string[] args)
        {
            //ToDo == Create Méthod to store Character

            Display.Affichage();
            Console.WriteLine("_________________________");
            int x, y;

            //Console.Clear();
            origRow = Console.CursorTop;
            origCol = Console.CursorLeft;

            #region Char "S"

            /////<summary>
            ///// C1
            ///// </summary>
            //for (x = 3; x < 21; x++)
            //{
            //    for (y = 1; y < 3; y++)
            //    {
            //        WriteAt("#", x, y);
            //    }
            //}

            /////<summary>
            ///// C2
            ///// </summary>
            //for (x = 2; x < 5; x++)
            //{
            //    for (y = 3; y < 8; y++)
            //    {
            //        WriteAt("#", x, y);
            //    }
            //}

            /////<summary>
            ///// C3
            ///// </summary>
            //for (x = 3; x < 19; x++)
            //{
            //    for (y = 8; y < 10; y++)
            //    {
            //        WriteAt("#", x, y);
            //    }
            //}

            /////<summary>
            ///// C4
            ///// </summary>
            //for (x = 17; x < 21; x++)
            //{
            //    for (y = 9; y < 11; y++)
            //    {
            //        WriteAt("#", x, y);
            //    }
            //}

            /////< summary >
            ///// C5
            /////</ summary >
            //for (x = 19; x < 21; x++)
            //{
            //    for (y = 11; y < 15; y++)
            //    {
            //        WriteAt("#", x, y);
            //    }
            //}


            /////<summary>
            ///// C1
            ///// </summary>
            //for (x = 3; x < 21; x++)
            //{
            //    for (y = 1; y < 3; y++)
            //    {
            //        WriteAt("#", x, y);
            //    }
            //}

            /////<summary>
            ///// C2
            ///// </summary>
            //for (x = 2; x < 5; x++)
            //{
            //    for (y = 3; y < 8; y++)
            //    {
            //        WriteAt("#", x, y);
            //    }
            //}

            /////<summary>
            ///// C3
            ///// </summary>
            //for (x = 3; x < 19; x++)
            //{
            //    for (y = 8; y < 10; y++)
            //    {
            //        WriteAt("#", x, y);
            //    }
            //}

            /////<summary>
            ///// C4
            ///// </summary>
            //for (x = 17; x < 21; x++)
            //{
            //    for (y = 9; y < 11; y++)
            //    {
            //        WriteAt("#", x, y);
            //    }
            //}

            /////<summary>
            ///// C5
            ///// </summary>
            //for (x = 19; x < 21; x++)
            //{
            //    for (y = 11; y < 15; y++)
            //    {
            //        WriteAt("#", x, y);
            //    }
            //}

            /////<summary>
            ///// C6
            ///// </summary>
            //for (x = 17; x < 21; x++)
            //{
            //    for (y = 15; y < 17; y++)
            //    {
            //        WriteAt("#", x, y);
            //    }
            //}

            /////<summary>
            ///// C7
            ///// </summary>
            //for (x = 3; x < 19; x++)
            //{
            //    for (y = 16; y < 18; y++)
            //    {
            //        WriteAt("#", x, y);
            //    }
            //}

            //Console.WriteLine();

            #endregion

            #region Char "M"

            ///<summary>
            ///Colonne gauche
            /// </summary>
            for (x = 1; x < 4; x++)
            {
                for (y = 4; y < 18; y++)
                {
                    WriteAt("#", x, y);
                }
            }

            ///<summary>
            ///Remplissage branche M Gauche
            /// </summary>

            for (x = 4; x < 5; x++)
            {
                for (y = 4; y < 7; y++)
                {
                    WriteAt("#", x, y);
                }
            }

            for (x = 5; x < 6; x++)
            {
                for (y = 5; y < 8; y++)
                {
                    WriteAt("#", x, y);
                }
            }

            for (x = 6; x < 7; x++)
            {
                for (y = 6; y < 9; y++)
                {
                    WriteAt("#", x, y);
                }
            }

            for (x = 7; x < 8; x++)
            {
                for (y = 7; y < 10; y++)
                {
                    WriteAt("#", x, y);
                }
            }

            for (x = 8; x < 9; x++)
            {
                for (y = 8; y < 11; y++)
                {
                    WriteAt("#", x, y);
                }
            }

            for (x = 9; x < 10; x++)
            {
                for (y = 8; y < 11; y++)
                {
                    WriteAt("#", x, y);
                }
            }

            ///<summary>
            ///Pointe Gauche M
            /// </summary>
            WriteAt("#", 1, 2);
            WriteAt("#", 1, 3);
            WriteAt("#", 2, 3);

            ///<summary>
            ///Pointe M
            /// </summary>
            for (x = 10; x < 13; x++)
            {
                for (y = 8; y < 11; y++)
                {
                    WriteAt("#", x, y);
                }
            }

            ///<summary>
            ///Remplissage branche M Droite
            /// </summary>

            for (x = 18; x < 19; x++)
            {
                for (y = 4; y < 7; y++)
                {
                    WriteAt("#", x, y);
                }
            }

            for (x = 17; x < 18; x++)
            {
                for (y = 5; y < 8; y++)
                {
                    WriteAt("#", x, y);
                }
            }

            for (x = 16; x < 17; x++)
            {
                for (y = 6; y < 9; y++)
                {
                    WriteAt("#", x, y);
                }
            }

            for (x = 15; x < 16; x++)
            {
                for (y = 7; y < 10; y++)
                {
                    WriteAt("#", x, y);
                }
            }

            for (x = 14; x < 15; x++)
            {
                for (y = 8; y < 11; y++)
                {
                    WriteAt("#", x, y);
                }
            }

            for (x = 13; x < 14; x++)
            {
                for (y = 8; y < 11; y++)
                {
                    WriteAt("#", x, y);
                }
            }

            WriteAt("#", 10, 11);
            WriteAt("#", 11, 11);
            WriteAt("#", 12, 11);



            ///<summary>
            ///Point droite M
            /// </summary>
            WriteAt("#", 21, 2);
            WriteAt("#", 21, 3);
            WriteAt("#", 20, 3);


            ///<summary>
            ///Colonne Droite
            /// </summary>
            for (x = 19; x < 22; x++)
            {
                for (y = 4; y < 18; y++)
                {
                    WriteAt("#", x, y);
                }
            }

            Console.WriteLine();
            #endregion

        }//End of Main

        /// <summary>
        /// Méthode permettant d'écrire selon certains points de coordonnées
        /// dans la console
        /// </summary>
        /// <param name="s"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        protected static void WriteAt(string s, int x, int y)
        {
            try
            {
                Console.SetCursorPosition(origCol + x, origRow + y);
                Console.Write(s);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }
        }

    }
}
