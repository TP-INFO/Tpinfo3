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
      _buffer = new char[WIDTH, HIGHT];
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
        _buffer[x, y] = (c == PixelColor.Black) ? FullPixelChar : EmptyPixelChar;


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
      for (int i = 0; i < c.HIGHT; i++) {
        for (int j = 0; j < c.WIDTH; j++) {
          //DrawPixel(XCursor + i, YCursor + j, )
          if (c._content[i, j] == FullPixelChar) {
            DrawPixel(i + YCursor, j + XCursor, PixelColor.Black);
          }
          else {
            DrawPixel(i + YCursor, j + XCursor, PixelColor.White);
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
        tmpChar = f._chars[s[i] - f.StarChar]; // get the current character from the char set

        if (WIDTH - XCursor < tmpChar.WIDTH) { // is there enough space for the next character. we can split words
          XCursor = 0;
          YCursor += tmpChar.HIGHT;
        }

        DrawChar(tmpChar, XCursor, YCursor);
        XCursor += (tmpChar.WIDTH + f.SPACEWIDTH); // update XCursor

      }

    }

  }
}
