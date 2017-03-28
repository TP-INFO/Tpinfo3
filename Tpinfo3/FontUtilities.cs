using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace Tpinfo3 {
  static class FontUtilities {
    /// <summary>
    /// Converts a byte to a series of # spaces corresponding to 1 and 0
    /// </summary>
    /// <param name="b"></param>
    /// <param name="length"></param>
    /// <returns></returns>
    public static char[] ByteToVector(byte b, int length) {
      char[] ctr = new char[length];
      byte mask = 0x80;
      for (int i = 0; i < length; i++) {
        if ((b & (byte)(mask >> i)) == 0) {
          ctr[i] = ' ';
        }
        else {
          ctr[i] = '#';
        }
      }

      return ctr;
    }

    public static byte HexaStringToByte(string str) {

      return (byte)(ChartoByte(str[2]) * 16 + ChartoByte(str[3]));
    }

    public static byte ChartoByte(char c) {
      if (char.IsDigit(c)) {
        return (byte)(c - '0');
      }
      else if (Char.IsLetter(c)) {
        return (Byte)(c - 'A' + 10);
      }
      else
        return 0;



    }

    public static Font ParseFonTtextFile(string path) {
      Font f = new Font();
      string strLine;
      char startChar, endChar;
      int spaceWidth, charHight;


      using (StreamReader sr = new StreamReader(path)) {
        try {
          // TODO: UseRegex in future release;
          // may be use an xml format instead of text files 
          // read first line: Must start with FontInfo
          strLine = sr.ReadLine();
          if (strLine != "FontInfo") {
            throw new Exception("no FontInfodirective was found");
          }

          // Read line of font Info
          /** Exemple : 
          // 11, //  Character height
          // 2, //  Width, in pixels, of space character
          // '0', //  Start character
          // 'z', //  End character
          */
          // character Hight
          strLine = sr.ReadLine();
          string pattern = @"(\d+)";
          Regex rgx = new Regex(pattern, RegexOptions.IgnoreCase);
          MatchCollection matches = rgx.Matches(strLine);
          if (matches.Count == 0)
            throw new Exception("Error during hight reading");
          f.HIGH = Convert.ToInt32(matches[0].Value);

          // read space width 
          strLine = sr.ReadLine();
          matches = rgx.Matches(strLine);
          if (matches.Count == 0)
            throw new Exception("Error during space width ");
          f.SPACEWIDTH = Convert.ToInt32(matches[0].Value);

          // read start char 
          strLine = sr.ReadLine();
          f.StartChar = strLine[1];
          // read endchar 
          strLine = sr.ReadLine();
          f.EndChar = strLine[1];

          // Read descriptors
          /**Exemple:
                    \t{width, 0}  // char
                    \t{5, 0}, 		// 0
          read width of each character and the corresponding char.
          store width and char in newly created var of type Character and store

          */
          strLine = sr.ReadLine();
          if (strLine != "Descriptors")
            throw new Exception("No discriptors where found");
          while ((strLine = sr.ReadLine()) != "EndDescriptors") { // TODO: add second test to ensure escaping from inifit loop
                                                                  // maybe max Nb off chars

            Character tmpChar = new Character();
            // widths
            pattern = @"(\d+)";
            rgx = new Regex(pattern, RegexOptions.IgnoreCase);
            matches = rgx.Matches(strLine);
            if (matches.Count == 0)
              throw new Exception("Error reading char width");
            tmpChar.WIDTH = Convert.ToInt32(matches[0].Value);

            // Hight : TODO. char hight is the same for all characters 
            tmpChar.HIGHT = f.HIGH;

            // char 
            pattern = @"//\s.";
            rgx = new Regex(pattern);
            matches = rgx.Matches(strLine); // should give "// c"
            tmpChar.CHAR = matches[0].Value[3];



            // store char inside
            f.AddChar(tmpChar);
          }
          
          // Read bitmap representation of each character
          strLine = sr.ReadLine();
          if (strLine != "Bitmaps")
            throw new Exception("No Bitmaps where found");
          // reading the bitmaps representations line by line 
          // and store them in Character._contents.
          // char[,] _content will have [Character.HIGHT,Character.WIDTH] size 

          int iChar = 0; // counter for character to update in the Font f

          do {
            strLine = sr.ReadLine();

            // pass non bitmap representation
            // empty line, and line like this one :
            //                                     // @11 '1' (3 pixels wide)
            if (string.IsNullOrEmpty(strLine))
              continue; // pass 

            if (strLine.Contains("@"))
              continue;

            /** Reading the bitmaps
              Exemple: 	0x70, //  ### 
	                      0x88, // #   #
	                      0x88, // #   #
	                      0x88, // #   #
	                      0x88, // #   #
	                      0x88, // #   #
	                      0x88, // #   #
	                      0x88, // #   #
	                      0x70, //  ### 
	                      0x00, //      
	                      0x00, //

            */

            int iLineBitmap = f.HIGH; // the hight of characters expressend in lines
                                      // we need to copy eeach line to a tmpCharContent table
                                      // then store it to the correspondig character in Font collection

            char[,] TmpCharbitmap = new char[f.HIGH, f._chars[iChar].WIDTH];
            for (int i = 0; i < iLineBitmap; i++) {
     
              int startIndex = strLine.IndexOf("//") + 3; // index of the first valid char of bitmap representation 
                                                          // for the current line 
              CopyStringToChar(TmpCharbitmap, strLine, i, startIndex, f._chars[iChar].WIDTH);
              strLine = sr.ReadLine();   // read a line in char bitmap

            }
            f._chars[iChar]._content = TmpCharbitmap; // Store the bitmap in the font collection 
            ++iChar; // move to the next character in the font collection 

          } while (strLine != "EndBitmaps");


          return f;

        }
        catch (Exception e) {
          Console.WriteLine(e.Message);
          return null;
        }
         
      }



































    }

    /// <summary>
    /// Strore characters from a string to a line of 2D array on character 
    /// The caller insures the compatibility of the dimensions of str and Chars 
    /// </summary>
    /// <param name="Chars"><value>Destination character array </value></param>
    /// <param name="str"><value> source string</value></param>
    /// <param name="iLine"><value> Index of the line in Chars array </value></param>
    /// <param name="startIndex"> start index in the string </param>
    /// <param name="width"> number of character to be compied</param>
    private static void CopyStringToChar(char[,] Chars, string str, 
                                         int iLine, 
                                         int startIndex,
                                         int  width) {


      char[] charLine = str.ToCharArray(startIndex, width);
      for (int j = 0; j < width; j++) {
        Chars[iLine, j] = charLine[j];
        //Console.Write(charLine[j]);
      }
      //Console.WriteLine();
    }
    



    
  }
}
