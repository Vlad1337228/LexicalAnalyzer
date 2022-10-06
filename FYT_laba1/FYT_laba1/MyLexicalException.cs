using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FYT_laba1
{
    public class MyLexicalException : Exception
    {

        public int LineIndex { get; }
        public int SymbolIndex { get; }
        public MyLexicalException(string message, int lineIndex, int symIndex) : base (message)
        {
            LineIndex = lineIndex;
            SymbolIndex = symIndex;
        }

        public MyLexicalException(string message) : base(message)
        {
            LineIndex = 0;
            SymbolIndex = 0;
        }
    }
}
