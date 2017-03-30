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
            Display.Affichage();

            int x, y;

            //Console.Clear();
            origRow = Console.CursorTop;
            origCol = Console.CursorLeft;

            #region Char "S"

            ///<summary>
            /// C1
            /// </summary>
            for (x = 3; x < 21; x++)
            {
                for (y = 1; y < 3; y++)
                {
                    WriteAt("#", x, y);
                }
            }



            ///<summary>
            /// C2
            /// </summary>
            for (x = 2; x < 5; x++)
            {
                for (y = 3; y < 8; y++)
                {
                    WriteAt("#", x, y);
                }
            }

            ///<summary>
            /// C3
            /// </summary>
            for (x = 3; x < 19; x++)
            {
                for (y = 8; y < 10; y++)
                {
                    WriteAt("#", x, y);
                }
            }

            ///<summary>
            /// C4
            /// </summary>
            for (x = 17; x < 21; x++)
            {
                for (y = 9; y < 11; y++)
                {
                    WriteAt("#", x, y);
                }
            }

            ///<summary>
            /// C5
            /// </summary>
            for (x = 19; x < 21; x++)
            {
                for (y = 11; y < 15; y++)
                {
                    WriteAt("#", x, y);
                }
            }

            ///<summary>
            /// C6
            /// </summary>
            for (x = 17; x < 21; x++)
            {
                for (y = 15; y < 17; y++)
                {
                    WriteAt("#", x, y);
                }
            }

            ///<summary>
            /// C7
            /// </summary>
            for (x = 3; x < 19; x++)
            {
                for (y = 16; y < 18; y++)
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
