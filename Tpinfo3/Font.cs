using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tpinfo3 {


  class Font {

    /// <summary>
    /// 
    /// </summary>

    public Character STARTCHAR { get; set; }
    public Character ENDCHAR { get; set; }
    public int SPACEWIDTH { get; set; }
    public char StarChar { get; set; }
    public char EndChar { get; set; }
    public int HIGH { get; set; }


    public List<Character> _chars = new List<Character>();

    /// <summary>
    /// Defaullt constructor: generates an empty 
    /// </summary>

    public Font() { }
    public Font(Character startChar, Character endChar, int spaceWidth) {
      STARTCHAR = startChar;
      ENDCHAR = endChar;
      SPACEWIDTH = spaceWidth;
      //_chars.Insert(0, startChar);
      //_chars.Add(endChar);
      StarChar = startChar.CHAR;
      EndChar = endChar.CHAR;
    }



    /// <summary>
    /// used to construct the font
    /// </summary>
    /// <param name="c"></param>
    public void AddChar(Character c) {
      _chars.Add(c);
    }

  }

  class Character {

    public int WIDTH { get; set; }
    public int HIGHT { get; set; }
    public char CHAR { get; set; }

    public char[,] _content = null;

    public Character() {

    }

    public Character(int width, int hight, char c) {
      WIDTH = width;
      HIGHT = hight;
      CHAR = c;
      _content = new char[hight, width];

    }
  } // end char



}

