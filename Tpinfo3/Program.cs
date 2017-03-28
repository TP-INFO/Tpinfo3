using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace Tpinfo3
{
  class Program
  {
    static void Main(string[] args)
    {

      //file path 
      string path = @"C:\Users\34011-36-05\Source\Repos\Tpinfo3\FontDefinitions.txt";

      if (!File.Exists(path))
      {
        Console.WriteLine("file does not exists ");
        System.Environment.Exit(0);
      }

      Font f = FontUtilities.ParseFonTtextFile(path);

      

      LCD lcd = new LCD(64, 64);
                  
      for (int i = 0; i < lcd.WIDTH; i++) {
        for (int j = 0; j < lcd.HIGHT; j++) {
          lcd.DrawPixel(i, j, PixelColor.Black);
        }
      }
      lcd.Display();
      System.Threading.Thread.Sleep(1000);
      lcd.Clear();
      lcd.Display();

      
      lcd.DrawText(f, "0123AB/CDabcd", 0, 0);
      lcd.Display();






      byte b = 0x70;
      //Console.WriteLine(b);

      char[] ctr = FontUtilities.ByteToVector(19, 8);

      foreach (var item in ctr) {
        Console.Write(item);
      }
    }
  }
  
}
 

 