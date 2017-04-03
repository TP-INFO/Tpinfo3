using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tpinfo3
{
	static class Print
	{

		public static void AfficherPrint(char arg)
		{
			// conditionnelle if: spécifique à la lettre F
			if ((arg == 'f') || (arg == 'F'))
			{
				char[,] matrice = new char[20, 20];

				for (int i = 0; i < 20; i++)
				{
					for (int j = 10; j < 20; j++)  // barre horizontale haute du F
					{
						char cLight = '#';
						matrice[i, 10] = cLight;
						matrice[0, j] = cLight;		// barre verticale du F
					}
				}

				for (int j = 10; j < 20; j++)
				{
					char cLight = 'k';
					matrice[10, j] = cLight;		// barre horizontale milieu du F
				}

				//Appel de la méthode AfficherMatrice
				AfficherMatrice(matrice);

			}
		}


		/// <summary>
		/// méthode pour afficher le tableau Matrice selon les dimensions 0 et 1;
		/// et selon ses propres i & j
		/// </summary>
		/// <param name="matrice"></param>
		public static void AfficherMatrice(char[,] matrice)
		{
			for (int i = 0; i < matrice.GetLength(0); i++)
			{
				for (int j = 0; j < matrice.GetLength(1); j++)
				{
					Console.Write(matrice[i, j]);
				}
				Console.WriteLine();


			}
		}
	}
}


