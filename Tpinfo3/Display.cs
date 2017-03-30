using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tpinfo3
{
    static class Display
    {
        /// <summary>
        /// Méthode peu performante pour afficher un caractère ..
        /// </summary>
        public static void Affichage()
        {
            int i, j, k, l, m;
            char[,] tab = new char[20, 20];

            for (i = 0; i < 20; i++)
            {
                for (j = 0; j < 20; j++)
                {
                    for (k = 3; k < 9; k++)
                    {
                        for (l = 4; l < 16; l++)
                        {
                            for (m = 11; m < 17; m++)
                            {

                                tab[2, l] = '#';
                                tab[1, l] = '#';

                                tab[k, 4] = '#';
                                tab[k, 5] = '#';

                                tab[9, l] = '#';
                                tab[10, l] = '#';

                                tab[m, 15] = '#';
                                tab[m, 14] = '#';

                                tab[17, l] = '#';
                                tab[18, l] = '#';

                            }
                            

                        }

                    }
                    Console.Write("{0} ", tab[i, j]);
                }
                Console.WriteLine();
            }
        }

        
    }
}
