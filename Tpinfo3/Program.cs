using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tpinfo3 {
  class Program {
    static void Main(string[] args) {


      Character A = new Character(7, 11, 'A');

      A._content = new char[,]
                  { { ' ',' ',' ','#',' ',' ',' '},
                    { ' ',' ',' ','#',' ',' ',' '},
                    { ' ',' ','#',' ','#',' ',' '},
                    { ' ',' ','#',' ','#',' ',' '},
                    { ' ','#',' ',' ',' ','#',' '},
                    { ' ','#',' ',' ',' ','#',' '},
                    { ' ','#','#','#','#','#',' '},
                    { '#',' ',' ',' ',' ',' ','#'},
                    { '#',' ',' ',' ',' ',' ','#'},
                    { ' ',' ',' ',' ',' ',' ',' '},
                    { ' ',' ',' ',' ',' ',' ',' '}
      };

      Character B = new Character(5, 11, 'B');
      B._content = new char[,]
        {
          {'#','#','#','#',' '},
          {'#',' ',' ',' ','#'},
          {'#',' ',' ',' ','#'},
          {'#',' ',' ',' ','#'},
          {'#','#','#','#',' '},
          {'#',' ',' ',' ','#'},
          {'#',' ',' ',' ','#'},
          {'#',' ',' ',' ','#'},
          {'#','#','#','#',' '},
          {' ',' ',' ',' ',' '},
          {' ',' ',' ',' ',' '}
        };


      Font f = new Font(A, B, 1);
      f.AddChar(A);
      f.AddChar(B);






      LCD lcd = new LCD(48, 48);

      //lcd.DrawChar(A);
      //lcd.DrawChar(f._chars['B' - f.StarChar], 20, 20);
      lcd.DrawText(f, "ABBBBBBBBBBBBBBBBBBBBBBBBB", 0, 0);
      //lcd.DrawChar(A,40,40);
      lcd.Display();
      //for (int i = 0; i < A.HIGHT; i++) {
      //  for (int j = 0; j < A.WIDTH; j++) {
      //    Console.Write(A._content[i,j]);
      //  }
      //  Console.WriteLine();
      //}





    }
  }
}
