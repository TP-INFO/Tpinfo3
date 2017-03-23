using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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



  }
}
