
using System;
using System.Text.RegularExpressions;

namespace Compiler
{
    internal class Lexer
    {
        static Token lexer(string strToLex)
        {

            switch (strToLex)
            { 
                case "const":return new Token("ключевое слово", TokenType.TOKEN_CONST);
                case "int": return new Token("ключевое слово", TokenType.TOKEN_INT);
                case "val":return new Token("ключевое слово", TokenType.TOKEN_VAL);
                case ":":return new Token("двоеточие", TokenType.TOKEN_COLON);
                case "=": return new Token("оператор присваивания", TokenType.TOKEN_EQUALS);
                case ";": return new Token("конец оператора", TokenType.TOKEN_SEMICOLON);
                case "{": return new Token("открывающая фигурная скобка", TokenType.TOKEN_OPEN_BRACE);
                case "}": return new Token("закрывающая фигурная скобка", TokenType.TOKEN_CLOSE_BRACE);
                case ",": return new Token("запятая", TokenType.TOKEN_COMMA);
                case " ": return new Token("разделитель", TokenType.TOKEN_WHITESPACE);
                case "\n":return new Token("разделитель",TokenType.TOKEN_WHITESPACE);
                default: break;
            }
            Regex ident = new Regex("[A-Za-z_]([A-Za-z_]|[0-9])*");
            Regex number = new Regex("[0-9]+");

            if (ident.IsMatch(strToLex))
            {
                Match match = ident.Match(strToLex);
                string str = match.Value;
                return new Token("идентификатор", TokenType.TOKEN_IDENT);
            }


            if (number.IsMatch(strToLex))
            {
                Match match = number.Match(strToLex);
                string str = match.Value;
                return new Token("число", TokenType.TOKEN_NUMBER);
            }
            return new Token("недопустимый символ", TokenType.TOKEN_ERROR);
        }

        public static string lexText(string text)
        {
            string temp = string.Empty;
            int current_line = 0;
            int start_pos = 0;
            int end_pos = 0;
            string finalText = string.Empty;

            if (text.Length == 0)
                return null;

            Token currentToken = lexer(text[0].ToString());
            Token tempToken;
            int countOfErrors = 0;
            for (int i = 0; i < text.Length; i++)
            {
                tempToken = lexer(text[i].ToString());
                if (currentToken.Type == TokenType.TOKEN_IDENT && tempToken.Type == TokenType.TOKEN_ERROR)
                {
                    tempToken = currentToken;
                }
                if (tempToken.Type != currentToken.Type)
                {
                    currentToken = lexer(temp);

                    end_pos--;

                    finalText += "Current Token: " + currentToken.Type + " - " + currentToken.Name + " - " + temp + " - " + " position" +
                        " [" + start_pos + "," + end_pos + "]" + " line: " + current_line + "\n";
                    if (temp == "\n")
                    {
                        current_line++;
                        start_pos = 0;
                        end_pos = 0;
                        temp = string.Empty;
                        currentToken = tempToken;
                    }
                    else
                    {
                        end_pos++;
                        start_pos = end_pos;
                        temp = string.Empty;
                        currentToken = tempToken;
                    }
                }

                temp += text[i];
                end_pos++;
            }
            currentToken = lexer(temp);
            end_pos--;
            finalText += "Current Token: " + currentToken.Type + " - " + currentToken.Name + " - " + temp + " - " + " position" +
                " [" + start_pos + "," + end_pos + "]" + " line: " + current_line + "\n";
            if (countOfErrors == 0)
            {
                finalText += "Ошибок нет";
            }
            return finalText;
        }
    }

    enum TokenType
    {
        TOKEN_INT = 1,
        TOKEN_CONST,
        TOKEN_COLON,
        TOKEN_VAL,
        TOKEN_IDENT,
        TOKEN_WHITESPACE,
        TOKEN_EQUALS,
        TOKEN_SEMICOLON,
        TOKEN_OPEN_BRACE,
        TOKEN_CLOSE_BRACE,
        TOKEN_COMMA,
        TOKEN_NUMBER,
        TOKEN_ERROR,
    };

    internal class Token
    {
        string name;
        TokenType type;
        public Token(string name, TokenType type)
        {
            this.name = name;
            this.type = type;
        }

        public string Name { get { return name; } set { name = value; } }
        public TokenType Type { get { return type; } set { type = value; } }
    }
}