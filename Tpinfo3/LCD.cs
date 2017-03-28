using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tpinfo3 {

  struct Cursor {
    public int XPOS { get; set; }
    public int YPOS { get; set; }
  }

  public enum PixelColor {
    Black,
    White
  }


  class LCD {
    /// <summary>
    /// Display width in pexels: for real world reasons, we prefer multiples of 8 
    /// </summary>
    private int _lcdWidth;
    /// <summary>
    /// Display hight in pexels 
    /// </summary>
    private int _lcdHight;

    private Cursor _cursor = new Cursor();
    private char[,] _buffer;
    private char FullPixelChar = '#';  // TODO: 
    private char EmptyPixelChar = ' ';


    // properties 
    public int WIDTH { get { return _lcdWidth; } set { _lcdWidth = value; } } // TODO: treat exceptions 
    public int HIGHT { get { return _lcdHight; } set { _lcdHight = value; } } // TODO: treat exceptions
    public int XCursor { get { return _cursor.XPOS; } set { _cursor.XPOS = value; } }
    public int YCursor { get { return _cursor.YPOS; } set { _cursor.YPOS = value; } }

    /// <summary>
    /// Default constructor : 48x48 pixels 
    /// </summary>
    public LCD() {
      WIDTH = 48;
      HIGHT = 48;
      XCursor = 0;
      YCursor = 0;
      _buffer = new char[HIGHT, WIDTH];
    }

    public LCD(int width, int hight) {
      WIDTH = width;
      HIGHT = hight;
      XCursor = 0;
      YCursor = 0;
      _buffer = new char[HIGHT, WIDTH];
    }

    /// <summary>
    /// Draw a pixel
    /// </summary>
    /// <param name="x">X position starting from upperLeft</param>
    /// <param name="y">y position starting from upperLeft</param>
    /// <param name="c"><value> Black or White</value></param>
    public void DrawPixel(int x, int y, PixelColor c) {
      if (x >= 0 && x < WIDTH && y >= 0 && y < HIGHT)
        _buffer[y, x] = (c == PixelColor.Black) ? FullPixelChar : EmptyPixelChar;


      // draw pixel

    }

    /// <summary>
    /// Writes the buffer to the display : (console)
    /// </summary>
    public void Display() {
      SetConsole();
      Console.WriteLine();                       // TODO adapt length of str to the width of LCD
      Console.WriteLine(new string('=', WIDTH + 3));
      for (int i = 0; i < HIGHT; i++) {
        for (int j = 0; j < WIDTH; j++) {
          Console.Write(_buffer[i, j]);
          //Console.Write('#');
        }
        Console.WriteLine();
      }
    }

    /// <summary>
    /// Sets the console window to the appropriate size
    /// </summary>
    public void SetConsole() {
      Console.WindowWidth = WIDTH + 3;
      Console.WindowHeight = HIGHT + 3;
    }

    public void DrawChar(Character c) {
      // copy the character contents to the buffer 
      for (int i = 0; i < c.WIDTH; i++) {
        for (int j = 0; j < c.HIGHT; j++) {
          if (c._content[j, i] == FullPixelChar) {
            DrawPixel(i + XCursor, j + YCursor, PixelColor.Black);
          }
          else {
            DrawPixel(i + XCursor, j + YCursor, PixelColor.White);
          }
        }
      }
    }

    public void DrawChar(Character c, int xpos, int ypos) {
      XCursor = xpos;
      YCursor = ypos;
      DrawChar(c);
    }

    public void DrawText(Font f, string s, int xpos, int ypos) {
      XCursor = xpos;
      YCursor = ypos;
      Character tmpChar;
      for (int i = 0; i < s.Length; i++) {
        tmpChar = GetCharFromFont(f, s[i]); // get the current character from the char set
         
        if (WIDTH - XCursor < tmpChar.WIDTH) { // is there enough space for the next character. we can split words
          XCursor = 0;
          YCursor += tmpChar.HIGHT;
        }

        DrawChar(tmpChar, XCursor, YCursor);
        XCursor += (tmpChar.WIDTH + f.SPACEWIDTH); // update XCursor

      }
    }
    /// <summary>
    /// Function that parses a character and returns the corresponding Character bitmap
    /// and definition (Character type)
    /// </summary>
    /// <param name="f"><value>font used for the current text </value></param>
    /// <param name="c"><value> ascci character </value></param>
    /// <returns></returns>

    private Character GetCharFromFont(Font f, char c) {

      if (Char.IsDigit(c)) {
        return f._chars[c - '0'];
      }
      else if (char.IsLetter(c)) {
        // is it uppercase ?
        if (char.IsLower(c))
          return f._chars[c - 'a' + 37];
        else
          return f._chars[c - 'A' + 11];
      }
      else   // default character representing unknown char 
        return f._chars[10];   // ? in this case  
    }



    public void Clear() {
      for (int i = 0; i < HIGHT; i++) {
        for (int j = 0; j < WIDTH; j++) {
          _buffer[i, j] = EmptyPixelChar;
        }
      }
    }



  }
}
