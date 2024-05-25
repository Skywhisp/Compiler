using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Compiler.MainForm;
using System.Windows.Forms;
using Compiler;

namespace Compiler
{
    public class Parser
    {
        private List<Lexeme> lexemes;
        private int position;
        public int counter;
        public int flag;
        public List<LexemeType> expectedLexemes;
        public List<LexemeType> foundLexemes;
        public string str;

        public Parser(List<Lexeme> lexemes)
        {
            this.lexemes = lexemes;
            this.position = 0;
            this.counter = 0;
            flag = lexemes.Count;
        }

        public void Parse(DataGridView dataGridView1)
        {
            SkipEmptyLines();
            DEF(dataGridView1);
        }

        private void SkipEmptyLines()
        {
            while (position < lexemes.Count && lexemes[position].Type == LexemeType.NewStr)
            {
                position++;
            }
        }

        private void DEF(DataGridView dataGridView1)
        {
            try
            {
                int res = 0;

                for (int u = position; u < lexemes.Count; u++)
                {
                    if (lexemes[u].Type == LexemeType.NewStr)
                    {
                        flag = u;
                        break;
                    }
                    else
                    {
                        flag = lexemes.Count;
                    }
                }

                for (int u = position; u < flag; u++)
                {
                    if (lexemes[u].Type == LexemeType.Keyword)
                    {
                        res = 1;
                        break;
                    }
                }

                if (res == 0)
                {
                    dataGridView1.Rows.Add("Ожидалось ключевое слово 'const'", lexemes[position].StartPosition);
                    counter++;
                    DEFREM(dataGridView1);
                }
                else
                {
                    if (lexemes[position].Type == LexemeType.Keyword)
                    {
                        str += lexemes[position].Token;
                        position++;
                        DEFREM(dataGridView1);
                    }
                    else if (lexemes[position].Type == LexemeType.Invalid)
                    {
                        dataGridView1.Rows.Add($"Недопустимый символ '{lexemes[position].Token}'", lexemes[position].StartPosition);
                        position++;
                        counter++;
                        DEF(dataGridView1);
                    }
                }
            }
            catch (ArgumentOutOfRangeException)
            {
            }
        }


        private void DEFREM(DataGridView dataGridView1)
        {
            try
            {
                int res = 0;
                for (int u = position; u < flag; u++)
                {
                    if (lexemes[u].Type == LexemeType.Delimiter)
                    {
                        res = 1;
                        break;
                    }
                }

                if (res == 0)
                {
                    dataGridView1.Rows.Add("Ожидался пробел", lexemes[position].StartPosition);
                    counter++;
                    VAL(dataGridView1);
                }
                else
                {
                    if (lexemes[position].Type == LexemeType.Delimiter)
                    {
                        str += lexemes[position].Token;
                        position++;
                        VAL(dataGridView1);
                    }
                    else if (lexemes[position].Type == LexemeType.Invalid)
                    {

                        dataGridView1.Rows.Add($"Недопустимый символ '{lexemes[position].Token}'", lexemes[position].StartPosition);
                        counter++;
                        position++;
                        DEFREM(dataGridView1);
                    }

                    else if (lexemes[position].Type != LexemeType.Delimiter)
                    {
                        //dataGridView1.Rows.Add($"Cимвол '{lexemes[position].Token}'", lexemes[position].StartPosition);
                        //counter++;
                        position++;
                        DEFREM(dataGridView1);
                    }
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                dataGridView1.Rows.Add($"Неожиданный символ '\0'");
                counter++;
            }
        }

        private void VAL(DataGridView dataGridView1)
        {
            try
            {
                int res = 0;
                for (int u = position; u < flag; u++)
                {
                    if (lexemes[u].Type == LexemeType.Keyword_val)
                    {
                        res = 1;
                        break;
                    }
                }

                if (res == 0)
                {
                    dataGridView1.Rows.Add($"Ожидалось ключевое слово val", lexemes[position].StartPosition);
                    counter++;
                    VALREM(dataGridView1);
                }
                else
                {
                    if (lexemes[position].Type == LexemeType.Keyword_val)
                    {
                        str += lexemes[position].Token;
                        position++;
                        VALREM(dataGridView1);
                    }
                    else if (lexemes[position].Type == LexemeType.Invalid)
                    {

                        dataGridView1.Rows.Add($"Недопустимый символ '{lexemes[position].Token}'", lexemes[position].StartPosition);
                        counter++;
                        position++;
                        VAL(dataGridView1);
                    }
                    else if (lexemes[position].Type != LexemeType.Keyword_val)
                    {
                        dataGridView1.Rows.Add($"Cимвол '{lexemes[position].Token}'", lexemes[position].StartPosition);
                        counter++;
                        position++;
                        VAL(dataGridView1);
                    }
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                dataGridView1.Rows.Add($"Неожиданный символ '\0'");
                counter++;
            }
        }

        private void VALREM(DataGridView dataGridView1)
        {
            try
            {
                int res = 0;
                for (int u = position; u < flag; u++)
                {
                    if (lexemes[u].Type == LexemeType.Delimiter)
                    {
                        res = 1;
                        break;
                    }
                }

                if (res == 0)
                {
                    dataGridView1.Rows.Add("Ожидался пробел", lexemes[position].StartPosition);
                    counter++;
                    ID(dataGridView1);
                }
                else
                {
                    if (lexemes[position].Type == LexemeType.Delimiter)
                    {
                        str += lexemes[position].Token;
                        position++;
                        ID(dataGridView1);
                    }
                    else if (lexemes[position].Type == LexemeType.Invalid)
                    {

                        dataGridView1.Rows.Add($"Недопустимый символ '{lexemes[position].Token}'", lexemes[position].StartPosition);
                        counter++;
                        position++;
                        VALREM(dataGridView1);
                    }

                    else if (lexemes[position].Type != LexemeType.Delimiter)
                    {
                        //dataGridView1.Rows.Add($"Cимвол '{lexemes[position].Token}'", lexemes[position].StartPosition);
                        //counter++;
                        position++;
                        VALREM(dataGridView1);
                    }
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                dataGridView1.Rows.Add($"Неожиданный символ '\0'");
                counter++;
            }
        }

        private void ID(DataGridView dataGridView1)
        {
            try
            {
                int res = 0;
                for (int u = position; u < flag; u++)
                {
                    if (lexemes[u].Type == LexemeType.Identifier)
                    {
                        res = 1;
                        break;
                    }
                }

                if (res == 0)
                {
                    dataGridView1.Rows.Add("Ожидался идентификатор", lexemes[position].StartPosition);
                    counter++;
                    IDREM(dataGridView1);
                }
                else
                {
                    if (lexemes[position].Type == LexemeType.Identifier)
                    {
                        str += lexemes[position].Token;
                        position++;
                        IDREM(dataGridView1);
                    }
                    else if (lexemes[position].Type == LexemeType.Invalid)
                    {

                        dataGridView1.Rows.Add($"Недопустимый символ  '{lexemes[position].Token}'", lexemes[position].StartPosition);
                        counter++;
                        position++;
                        ID(dataGridView1);
                    }
                    else if (lexemes[position].Type != LexemeType.Identifier)
                    {
                        dataGridView1.Rows.Add($"Cимвол '{lexemes[position].Token}'", lexemes[position].StartPosition);
                        counter++;
                        position++;
                        ID(dataGridView1);
                    }
                }
            }

            catch (ArgumentOutOfRangeException)
            {
                dataGridView1.Rows.Add($"Неожиданный символ '\0'");
                counter++;
            }
        }

        private void IDREM(DataGridView dataGridView1)
        {
            try
            {
                // Skip optional delimiters (spaces) before the colon
                while (position < flag && lexemes[position].Type == LexemeType.Delimiter)
                {
                    position++;
                }

                if (position < flag && lexemes[position].Type == LexemeType.Colon)
                {
                    str += lexemes[position].Token;
                    position++;

                    // Skip optional delimiters (spaces) after the colon
                    while (position < flag && lexemes[position].Type == LexemeType.Delimiter)
                    {
                        position++;
                    }

                    TYPE(dataGridView1);
                }
                else if (position < flag && lexemes[position].Type == LexemeType.Invalid)
                {
                    dataGridView1.Rows.Add($"Недопустимый символ '{lexemes[position].Token}'", lexemes[position].StartPosition);
                    counter++;
                    position++;
                    IDREM(dataGridView1);
                }
                else
                {
                    dataGridView1.Rows.Add("Ожидалось двоеточие", lexemes[position].StartPosition);
                    counter++;
                    TYPE(dataGridView1);
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                dataGridView1.Rows.Add($"Неожиданный символ '\0'");
                counter++;
            }
        }

        private void TYPE(DataGridView dataGridView1)
        {
            try
            {
                int res = 0;
                for (int u = position; u < flag; u++)
                {
                    if (lexemes[u].Type == LexemeType.DataType)
                    {
                        res = 1;
                        break;
                    }
                }

                if (res == 0)
                {
                    dataGridView1.Rows.Add($"Ожидался тип данных Int", lexemes[position].StartPosition);
                    counter++;
                    TYPEREM(dataGridView1);
                }
                else
                {
                    if (lexemes[position].Type == LexemeType.DataType)
                    {
                        str += lexemes[position].Token;
                        position++;
                        TYPEREM(dataGridView1);
                    }
                    else if (lexemes[position].Type == LexemeType.Invalid)
                    {

                        dataGridView1.Rows.Add($"Недопустимый символ '{lexemes[position].Token}'", lexemes[position].StartPosition);
                        counter++;
                        position++;
                        TYPE(dataGridView1);
                    }
                    else if (lexemes[position].Type != LexemeType.DataType)
                    {
                        dataGridView1.Rows.Add($"Cимвол '{lexemes[position].Token}'", lexemes[position].StartPosition);
                        counter++;
                        position++;
                        TYPE(dataGridView1);
                    }
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                dataGridView1.Rows.Add($"Неожиданный символ '\0'");
                counter++;
            }
        }

        private void TYPEREM(DataGridView dataGridView1)
        {
            if (lexemes[position].Type == LexemeType.Delimiter)
            {
                position++;
                try
                {
                    int res = 0;
                    for (int u = position; u < flag; u++)
                    {
                        if (lexemes[u].Type == LexemeType.Equally)
                        {
                            res = 1;
                            break;
                        }
                    }

                    if (res == 0)
                    {
                        dataGridView1.Rows.Add("Ожидалось равно", lexemes[position].StartPosition);
                        counter++;
                        EQUAL(dataGridView1);
                    }
                    else
                    {
                        if (lexemes[position].Type == LexemeType.Equally)
                        {
                            str += lexemes[position].Token;
                            position++;
                            EQUAL(dataGridView1);
                        }
                        else if (lexemes[position].Type == LexemeType.Invalid)
                        {

                            dataGridView1.Rows.Add($"Недопустимый символ '{lexemes[position].Token}'", lexemes[position].StartPosition);
                            counter++;
                            position++;
                            TYPEREM(dataGridView1);
                        }

                        else if (lexemes[position].Type != LexemeType.Equally)
                        {
                            //dataGridView1.Rows.Add($"Cимвол '{lexemes[position].Token}'", lexemes[position].StartPosition);
                            //counter++;
                            position++;
                            TYPEREM(dataGridView1);
                        }
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    dataGridView1.Rows.Add($"Неожиданный символ '\0'");
                    counter++;
                }
            }
            else
            {
                try
                {
                    int res = 0;
                    for (int u = position; u < flag; u++)
                    {
                        if (lexemes[u].Type == LexemeType.Equally)
                        {
                            res = 1;
                            break;
                        }
                    }

                    if (res == 0)
                    {
                        dataGridView1.Rows.Add("Ожидалось равно", lexemes[position].StartPosition);
                        counter++;
                        EQUAL(dataGridView1);
                    }
                    else
                    {
                        if (lexemes[position].Type == LexemeType.Equally)
                        {
                            str += lexemes[position].Token;
                            position++;
                            EQUAL(dataGridView1);
                        }
                        else if (lexemes[position].Type == LexemeType.Invalid)
                        {

                            dataGridView1.Rows.Add($"Недопустимый символ '{lexemes[position].Token}'", lexemes[position].StartPosition);
                            counter++;
                            position++;
                            TYPEREM(dataGridView1);
                        }

                        else if (lexemes[position].Type != LexemeType.Equally)
                        {
                            //dataGridView1.Rows.Add($"Cимвол '{lexemes[position].Token}'", lexemes[position].StartPosition);
                            //counter++;
                            position++;
                            TYPEREM(dataGridView1);
                        }
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    dataGridView1.Rows.Add($"Неожиданный символ '\0'");
                    counter++;
                }
            }
        }

        private void EQUAL(DataGridView dataGridView1)
        {
            if (lexemes[position].Type == LexemeType.Delimiter)
            {
                position++;
                if ((lexemes[position].Type == LexemeType.Plus) || (lexemes[position].Type == LexemeType.Minus))
                {
                    str += lexemes[position].Token;
                    position++;
                    NUMBER(dataGridView1);
                }
                else
                {
                    NUMBER(dataGridView1);
                }
            }
            else if ((lexemes[position].Type == LexemeType.Plus) || (lexemes[position].Type == LexemeType.Minus))
            {
                str += lexemes[position].Token;
                position++;
                NUMBER(dataGridView1);
            }
            else
            {
                NUMBER(dataGridView1);
            }
        }

        private void NUMBER(DataGridView dataGridView1)
        {
            try
            {

                int res = 0;
                for (int u = position; u < flag; u++)
                {
                    if (lexemes[u].Type == LexemeType.Number)
                    {
                        res = 1;
                        break;
                    }
                }

                if (res == 0)
                {
                    dataGridView1.Rows.Add("Ожидалось число", lexemes[position].StartPosition);
                    counter++;
                    NUMBERREM(dataGridView1);
                }
                else
                {
                    if (lexemes[position].Type == LexemeType.Number)
                    {
                        str += lexemes[position].Token;
                        position++;
                        NUMBERREM(dataGridView1);
                    }
                    else if (lexemes[position].Type == LexemeType.Invalid)
                    {

                        dataGridView1.Rows.Add($"Недопустимый символ '{lexemes[position].Token}'", lexemes[position].StartPosition);
                        counter++;
                        position++;
                        NUMBER(dataGridView1);
                    }
                    else if (lexemes[position].Type != LexemeType.Number)
                    {
                        dataGridView1.Rows.Add($"Символ '{lexemes[position].Token}'", lexemes[position].StartPosition);
                        counter++;
                        position++;
                        NUMBER(dataGridView1);
                    }
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                dataGridView1.Rows.Add($"Неожиданный символ '\0'");
                counter++;
            }
        }

        private void NUMBERREM(DataGridView dataGridView1)
        {
            try
            {
                int res = 0;
                for (int u = position; u < flag; u++)
                {
                    if (lexemes[u].Type == LexemeType.Semicolon)
                    {
                        res = 1;
                        break;
                    }
                }

                if (res == 0)
                {
                    dataGridView1.Rows.Add($"Ожидалась точка с запятой", lexemes[position - 1].EndPosition + 1);
                    counter++;
                    END(dataGridView1);//?
                }
                else
                {

                    if (lexemes[position].Type == LexemeType.Semicolon)
                    {
                        str += lexemes[position].Token;
                        position++;
                        END(dataGridView1);
                    }
                    else if (lexemes[position].Type == LexemeType.Invalid)
                    {
                        dataGridView1.Rows.Add($"Недопустимый символ '{lexemes[position].Token}'", lexemes[position].StartPosition);
                        counter++;
                        position++;
                        NUMBERREM(dataGridView1);
                    }
                    else if (lexemes[position].Type != LexemeType.Semicolon)
                    {
                        dataGridView1.Rows.Add($"Cимвол '{lexemes[position].Token}'", lexemes[position].StartPosition);
                        counter++;
                        position++;
                        NUMBERREM(dataGridView1);
                    }
                }
            }
            catch (ArgumentOutOfRangeException)
            {

                dataGridView1.Rows.Add($"Неожиданный символ '\0'");
                counter++;
            }
        }

        private void END(DataGridView dataGridView1)
        {
            try
            {
                if (position < lexemes.Count)
                {
                    if (lexemes[position].Type == LexemeType.Invalid)
                    {
                        dataGridView1.Rows.Add($"Недопустимый символ '{lexemes[position].Token}'", lexemes[position].StartPosition);
                        counter++;
                        position++;
                        END(dataGridView1);
                    }
                    else if (lexemes[position].Type == LexemeType.Semicolon)
                    {
                        str += lexemes[position].Token;
                        position++;
                        if (lexemes[position].Type == LexemeType.Semicolon)
                        {
                            dataGridView1.Rows.Add($"Недопустимый символ '{lexemes[position].Token}'", lexemes[position].StartPosition);
                            counter++;
                            position++;
                            END(dataGridView1);
                        }
                        if (position < lexemes.Count && lexemes[position].Type == LexemeType.NewStr)
                        {
                            position++;
                            DEF(dataGridView1);
                        }
                    }
                    else if (lexemes[position].Type == LexemeType.NewStr)
                    {
                        position++;
                        DEF(dataGridView1);
                    }
                    else if (lexemes[position].Type != LexemeType.Invalid && lexemes[position].Type != LexemeType.Delimiter)
                    {
                        dataGridView1.Rows.Add($"Cимвол '{lexemes[position].Token}'", lexemes[position].StartPosition);
                        counter++;
                        position++;
                        END(dataGridView1);
                    }
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                dataGridView1.Rows.Add($"Неожиданный символ '\0'");
                counter++;
            }
        }
    }
}
