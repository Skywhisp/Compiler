using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler
{
    public class Lexeme
    {
        public int Code { get; set; }
        public LexemeType Type { get; set; }
        public string Token { get; set; }
        public int StartPosition { get; set; }
        public int EndPosition { get; set; }

        public Lexeme(int code, LexemeType type, string input, int startPosition, int endPosition)
        {
            Code = code;
            Type = type;
            Token = input.Substring(startPosition, endPosition - startPosition + 1);
            StartPosition = startPosition;
            EndPosition = endPosition;
        }
    }

    public enum LexemeType
    {
        Keyword,
        Keyword_val,
        Identifier,
        Delimiter,
        Colon,
        DataType,
        Equally,
        Minus,
        Plus,
        Number,
        Semicolon,
        Invalid,
        EndStr,
        NewStr
    }
}
