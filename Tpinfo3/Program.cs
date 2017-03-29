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

      //Font defintion file
      string fileName = @"FontDefinitions.txt";
      
      DirectoryInfo dir = new DirectoryInfo(Directory.GetCurrentDirectory());
      Console.WriteLine(dir.Parent.FullName);
      string path = dir.Parent.FullName + "\\" + fileName; 
      
      

      if (!File.Exists(path))
      {
        Console.WriteLine("file does not exists ");
        System.Environment.Exit(0);
      }

      Font f = FontUtilities.ParseFonTtextFile(path);

      

      LCD lcd = new LCD(64, 64);


      lcd.Fill();

      lcd.Display();
      System.Threading.Thread.Sleep(1000);
      lcd.Clear();
      lcd.Display();

      
      lcd.DrawText(f, "Ben is dangerous", 0, 0);
      lcd.Display();
      
    
    }
  }  
}