using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace Tpinfo3 {
  class Program {
    static void Main(string[] args) {

      //file path 
      string path = @"C:\Users\34011-36-05\Source\Repos\Tpinfo3\FontDefinitions.txt";

      if (!File.Exists(path)) {
        Console.WriteLine("file does not exists ");
        System.Environment.Exit(0);
      }

      Font f = new Font();
      

      using (StreamReader sr = new StreamReader(path)) {
        string strLine;
        char startChar, endChar;
        int spaceWidth, charHight;
       

        try {
          //TODO : Use REGEX properly 
          // first line: FontInfo
          strLine = sr.ReadLine();
          if(strLine != "FontInfo") {
            throw new Exception("First line diff de FontInfo");
          }
          // read lines of Font Info
          strLine = sr.ReadLine(); // character height
          string pattern = @"^\d+";
          Regex rgx = new Regex(pattern, RegexOptions.IgnoreCase);
          MatchCollection matches = rgx.Matches(strLine);
          if (matches.Count == 0)
            throw new Exception("problem at Hight");
          charHight = Convert.ToInt32(matches[0].Value);
          f.HIGH = charHight;

          strLine = sr.ReadLine(); // spacewidth
          rgx = new Regex(pattern, RegexOptions.IgnoreCase);
          matches = rgx.Matches(strLine);
          if (matches.Count == 0)
            throw new Exception("problem at Space");
          spaceWidth = Convert.ToInt32(matches[0].Value);
          f.SPACEWIDTH = spaceWidth;

          
          
          strLine = sr.ReadLine(); // read startChar
          
          startChar = strLine[1];

          strLine = sr.ReadLine(); // read startChar
          endChar = strLine[1];

          // Read Descriptors 
          if ((strLine = sr.ReadLine()) != "Descriptors")
            throw new Exception("Problem reading descriptors ");
          while ((strLine = sr.ReadLine()) != "EndDescriptors") {


            // extract the widths 
            pattern = @"(\d+)";
            rgx = new Regex(pattern, RegexOptions.IgnoreCase);
            matches = rgx.Matches(strLine);
           
            Console.WriteLine();
            Character tmpChar = new Character();
            tmpChar.WIDTH = Convert.ToInt32(matches[0].Value);

            Console.WriteLine(tmpChar.WIDTH);
            // extracting the corresponding characters 
            pattern = @"//\s.";
            rgx = new Regex(pattern, RegexOptions.IgnoreCase);
            matches = rgx.Matches(strLine);
            tmpChar.CHAR = matches[0].Value[3];
            //Console.WriteLine(tmpChar.CHAR);
            f.AddChar(tmpChar);
          }


          // stock bitmap representation

          

          if ((strLine = sr.ReadLine())!="Bitmaps") {
            throw new Exception("No Bitmaps");
          }

          int iChar = 0; // counter for caracters 


          while ((strLine = sr.ReadLine()) != "EndBitmaps") {
            // skip empty lines and comment lines 
            if (String.IsNullOrEmpty(strLine)) {
              continue;
            }
            if (strLine[1] =='/') {
              continue;
            }


            // Store bitmap representation in corresponding slot in f._chars (_content);

            int i = f.HIGH;
            char[,] tmpCharContent = new char[f.HIGH, f._chars[iChar].WIDTH];
            char[] tmpCharLine = new char[f._chars[iChar].WIDTH];
            pattern = @"[A-F0-9]";
            rgx = new Regex(pattern, RegexOptions.IgnoreCase);
            
            do {

              matches = rgx.Matches(strLine);
              StringBuilder hexaNum = new StringBuilder();
              
              foreach (Match item in matches) { // store tockens to stringbuilder
                hexaNum.Append(item.Value);
              }

              string hexString = hexaNum.ToString();
              byte tmpByte = FontUtilities.HexaStringToByte(hexString);
              tmpCharLine = FontUtilities.ByteToVector(tmpByte, f._chars[iChar].WIDTH);
              



            } while (i > 0);

           

            
            //Console.WriteLine(hexaNum);
            //Console.Write("{0}: {1}",hexaNum, Convert.ToByte(hexaNum.ToString()));
            //Console.WriteLine("{0}, width : {1}", hexaNum, f._chars[i].WIDTH);

            ++i;
          }


        }
        catch (Exception e) {

          Console.WriteLine(e);
          System.Environment.Exit(0);
        }
      }

      









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


      //Font f = new Font(A, B, 1);
      //f.AddChar(A);
      //f.AddChar(B);






      LCD lcd = new LCD(64, 48);

      //lcd.DrawChar(A);
      //lcd.DrawChar(f._chars['B' - f.StarChar], 20, 20);
     // lcd.DrawText(f, "ABBBBBBBBBBBBBBBBBBBBBBBBB", 0, 0);
      //lcd.DrawChar(A,40,40);
     // lcd.Display();
      //for (int i = 0; i < A.HIGHT; i++) {
      //  for (int j = 0; j < A.WIDTH; j++) {
      //    Console.Write(A._content[i,j]);
      //  }
      //  Console.WriteLine();
      //}

      byte b = 0x70;
      //Console.WriteLine(b);

      char[] ctr = FontUtilities.ByteToVector(19, 8);

      foreach (var item in ctr) {
        Console.Write(item);
      }



    }

    

  }
}
