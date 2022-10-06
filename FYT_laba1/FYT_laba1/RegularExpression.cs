using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FYT_laba1
{
    public static class MyRegularExpression
    {

        enum CharToken
        {
            Number,
            Letter,
            Comment,
            EndComment,
            BadChar,
            Space,
            Unknown
        }

        enum CommentSymbol
        {
            slash,
            star,
            symbol,
            unknown
        }

        private static readonly List<char> charsList = new List<char>() {'a','b', 'c', 'd' };
        private static int indexCurrentSymbol = -1;
        private static CharToken currentSymbolToken = CharToken.Unknown;
        private static CharToken tokenWord = CharToken.Unknown;
        private static char currentSymbol = ' ';
        private static string originString;
        private static int indexStartWord = 0;
        private static CommentSymbol previousCommentToken = CommentSymbol.unknown;

        public static void StartAnalysis(string s)
        {
            Inicializ(s);

            if (!CheckString(originString))
            {
                throw new MyLexicalException("Ошибка: введите данные для обработки!");
            }
            RecognizeIdentifier();
        }

        private static void RecognizeIdentifier()
        {
            ReadNextSymbol();

            if(currentSymbolToken == CharToken.Number)
            {
                SearchNumbers();
            }
            else if(currentSymbolToken == CharToken.Letter)
            {
                SearchWord();
            }
            else if(currentSymbolToken == CharToken.Comment)
            {
                SearchComment();
                RecognizeIdentifier();
            }
            else if( currentSymbolToken == CharToken.Space)
            {
                indexStartWord = indexCurrentSymbol;
                RecognizeIdentifier();
            }
        }

        private static void SearchComment()
        {
            tokenWord = CharToken.Comment;
            indexStartWord++;
            goto A;

        A:
            if(currentSymbol == '/')
            {
                if(currentSymbolToken == CharToken.Comment)
                {
                    previousCommentToken = CommentSymbol.slash;
                    ReadNextSymbol();
                    goto B;
                }
            }
            throw new MyLexicalException("Лексикографическая ошибка. Строка " + SearchStartBadWord(), indexCurrentSymbol / 50, indexCurrentSymbol);
        B:
            if(currentSymbol == '*')
            {
                if(currentSymbolToken == CharToken.Comment && previousCommentToken == CommentSymbol.slash)
                {
                    previousCommentToken = CommentSymbol.star;
                    ReadNextSymbol();
                    goto C;
                }
            }
            throw new MyLexicalException("Лексикографическая ошибка. Строка " + SearchStartBadWord(), indexCurrentSymbol / 50, indexCurrentSymbol);
        C:
            if(currentSymbol == '*')
            {
                if(currentSymbolToken == CharToken.Comment)
                {
                    previousCommentToken = CommentSymbol.star;
                    ReadNextSymbol();
                    goto D;
                }
            }
            
            if(currentSymbol != '*' && currentSymbol != '/')
            {
                if (currentSymbolToken == CharToken.Comment)
                {
                    previousCommentToken = CommentSymbol.symbol;
                    ReadNextSymbol();
                    goto C;
                }
            }

            if(currentSymbol == '/')
            {
                if (currentSymbolToken == CharToken.Comment )
                {
                    previousCommentToken = CommentSymbol.slash;
                    ReadNextSymbol();
                    goto C;
                }
            }
            throw new MyLexicalException("Лексикографическая ошибка. Строка " + SearchStartBadWord(), indexCurrentSymbol / 50, indexCurrentSymbol);
        D:
            if(currentSymbol == '/')
            {
                if (previousCommentToken == CommentSymbol.star )
                {
                    previousCommentToken = CommentSymbol.slash;
                    tokenWord = CharToken.Unknown;
                    goto Fin;
                }
            }

            if (currentSymbol != '*' && currentSymbol != '/')
            {
                if (currentSymbolToken == CharToken.Comment)
                {
                    previousCommentToken = CommentSymbol.symbol;
                    ReadNextSymbol();
                    goto C;
                }
            }
            if (currentSymbol == '*')
            {
                if (currentSymbolToken == CharToken.Comment)
                {
                    previousCommentToken = CommentSymbol.star;
                    ReadNextSymbol();
                    goto D;
                }
            }
            throw new MyLexicalException("Лексикографическая ошибка. Строка " + SearchStartBadWord(), indexCurrentSymbol / 50, indexCurrentSymbol);
        
        
        
        Fin:
            return;

        }

        private static void SearchWord()
        {
            tokenWord = CharToken.Letter;
            indexStartWord++;
            goto A;


        A:
            if(currentSymbol == 'a')
            {
                if (indexCurrentSymbol + 1 < originString.Length)
                {
                    if (originString[indexCurrentSymbol + 1] == ' ')
                    {
                        tokenWord = CharToken.Unknown;
                        currentSymbolToken = CharToken.Unknown;
                        RecognizeIdentifier();
                        goto Fin;
                    }
                }
                else
                {
                    tokenWord = CharToken.Unknown;
                    currentSymbolToken = CharToken.Unknown;
                    goto Fin;
                }
                if (currentSymbolToken == CharToken.Letter)
                {
                    ReadNextSymbol();
                    goto B;
                }
            }

            if (currentSymbol == 'b')
            {
                if (indexCurrentSymbol + 1 < originString.Length)
                {
                    if (originString[indexCurrentSymbol + 1] == ' ')
                    {
                        tokenWord = CharToken.Unknown;
                        currentSymbolToken = CharToken.Unknown;
                        RecognizeIdentifier();
                        goto Fin;
                    }
                }
                else
                {
                    tokenWord = CharToken.Unknown;
                    currentSymbolToken = CharToken.Unknown;
                    goto Fin;
                }
                if (currentSymbolToken == CharToken.Letter)
                {
                    ReadNextSymbol();
                    goto C;
                }
            }

            if (currentSymbol == 'c')
            {
                if (indexCurrentSymbol + 1 < originString.Length)
                {
                    if (originString[indexCurrentSymbol + 1] == ' ')
                    {
                        tokenWord = CharToken.Unknown;
                        currentSymbolToken = CharToken.Unknown;
                        RecognizeIdentifier();
                        goto Fin;
                    }
                }
                else
                {
                    tokenWord = CharToken.Unknown;
                    currentSymbolToken = CharToken.Unknown;
                    goto Fin;
                }
                if (currentSymbolToken == CharToken.Letter)
                {
                    ReadNextSymbol();
                    goto C;
                }
            }

            if (currentSymbol == 'd')
            {
                if (indexCurrentSymbol + 1 < originString.Length)
                {
                    if (originString[indexCurrentSymbol + 1] == ' ')
                    {
                        tokenWord = CharToken.Unknown;
                        currentSymbolToken = CharToken.Unknown;
                        RecognizeIdentifier();
                        goto Fin;
                    }
                }
                else
                {
                    tokenWord = CharToken.Unknown;
                    currentSymbolToken = CharToken.Unknown;
                    goto Fin;
                }
                if (currentSymbolToken == CharToken.Letter)
                {
                    ReadNextSymbol();
                    goto C;
                }
            }
            throw new MyLexicalException("Лексикографическая ошибка. Строка " + SearchStartBadWord(), indexCurrentSymbol / 50, indexCurrentSymbol);

        B:
            if (currentSymbol == 'a')
            {
                if (indexCurrentSymbol + 1 < originString.Length)
                {
                    if (originString[indexCurrentSymbol + 1] == ' ')
                    {
                        tokenWord = CharToken.Unknown;
                        currentSymbolToken = CharToken.Unknown;
                        RecognizeIdentifier();
                        goto Fin;
                    }
                }
                else
                {
                    tokenWord = CharToken.Unknown;
                    currentSymbolToken = CharToken.Unknown;
                    goto Fin;
                }
                if (currentSymbolToken == CharToken.Letter)
                {
                    ReadNextSymbol();
                    goto B;
                }
            }

            if (currentSymbol == 'b')
            {
                if (indexCurrentSymbol + 1 < originString.Length)
                {
                    if (originString[indexCurrentSymbol + 1] == ' ')
                    {
                        tokenWord = CharToken.Unknown;
                        currentSymbolToken = CharToken.Unknown;
                        RecognizeIdentifier();
                        goto Fin;
                    }
                }
                else
                {
                    tokenWord = CharToken.Unknown;
                    currentSymbolToken = CharToken.Unknown;
                    goto Fin;
                }
                if (currentSymbolToken == CharToken.Letter)
                {
                    ReadNextSymbol();
                    goto C;
                }
            }

            if (currentSymbol == 'c')
            {
                if (indexCurrentSymbol + 1 < originString.Length)
                {
                    if (originString[indexCurrentSymbol + 1] == ' ')
                    {
                        tokenWord = CharToken.Unknown;
                        currentSymbolToken = CharToken.Unknown;
                        RecognizeIdentifier();
                        goto Fin;
                    }
                }
                else
                {
                    tokenWord = CharToken.Unknown;
                    currentSymbolToken = CharToken.Unknown;
                    goto Fin;
                }
                if (currentSymbolToken == CharToken.Letter)
                {
                    ReadNextSymbol();
                    goto C;
                }
            }
            throw new MyLexicalException("Лексикографическая ошибка. Строка " + SearchStartBadWord(), indexCurrentSymbol / 50, indexCurrentSymbol);

        C:
            if (currentSymbol == 'a')
            {
                if (indexCurrentSymbol + 1 < originString.Length)
                {
                    if (originString[indexCurrentSymbol + 1] == ' ')
                    {
                        tokenWord = CharToken.Unknown;
                        currentSymbolToken = CharToken.Unknown;
                        RecognizeIdentifier();
                        goto Fin;
                    }
                }
                else
                {
                    tokenWord = CharToken.Unknown;
                    currentSymbolToken = CharToken.Unknown;
                    goto Fin;
                }
                if (currentSymbolToken == CharToken.Letter)
                {
                    ReadNextSymbol();
                    goto B;
                }
            }

            if (currentSymbol == 'b')
            {
                if (indexCurrentSymbol + 1 < originString.Length)
                {
                    if (originString[indexCurrentSymbol + 1] == ' ')
                    {
                        tokenWord = CharToken.Unknown;
                        currentSymbolToken = CharToken.Unknown;
                        RecognizeIdentifier();
                        goto Fin;
                    }
                }
                else
                {
                    tokenWord = CharToken.Unknown;
                    currentSymbolToken = CharToken.Unknown;
                    goto Fin;
                }
                if (currentSymbolToken == CharToken.Letter)
                {
                    ReadNextSymbol();
                    goto C;
                }
            }

            if (currentSymbol == 'c')
            {
                if (indexCurrentSymbol + 1 < originString.Length)
                {
                    if (originString[indexCurrentSymbol + 1] == ' ')
                    {
                        tokenWord = CharToken.Unknown;
                        currentSymbolToken = CharToken.Unknown;
                        RecognizeIdentifier();
                        goto Fin;
                    }
                }
                else
                {
                    tokenWord = CharToken.Unknown;
                    currentSymbolToken = CharToken.Unknown;
                    goto Fin;
                }
                if (currentSymbolToken == CharToken.Letter)
                {
                    ReadNextSymbol();
                    goto C;
                }
            }

            if (currentSymbol == 'd')
            {
                if (indexCurrentSymbol + 1 < originString.Length)
                {
                    if (originString[indexCurrentSymbol + 1] == ' ')
                    {
                        tokenWord = CharToken.Unknown;
                        currentSymbolToken = CharToken.Unknown;
                        RecognizeIdentifier();
                        goto Fin;
                    }
                }
                else
                {
                    tokenWord = CharToken.Unknown;
                    currentSymbolToken = CharToken.Unknown;
                    goto Fin;
                }
                if (currentSymbolToken == CharToken.Letter)
                {
                    ReadNextSymbol();
                    goto C;
                }
            }
            throw new MyLexicalException("Лексикографическая ошибка. Строка " + SearchStartBadWord(), indexCurrentSymbol / 50, indexCurrentSymbol);


        Fin:
            return;
        }

        private static void SearchNumbers()
        {
            tokenWord = CharToken.Number;
            indexStartWord++;
            goto A;


        A:
            if (currentSymbol == '1') 
            {
                if(currentSymbolToken == CharToken.Number)
                {
                    ReadNextSymbol();
                    goto B;
                }
            }
            throw new MyLexicalException("Лексикографическая ошибка. Строка" + SearchStartBadWord(), indexCurrentSymbol / 50, indexCurrentSymbol);

        B:
            if(currentSymbol == '1')
            {
                if(currentSymbolToken == CharToken.Number)
                {
                    ReadNextSymbol();
                    goto C;
                }
            }
            else if(currentSymbol == '0')
            {
                if (currentSymbolToken == CharToken.Number)
                {
                    ReadNextSymbol();
                    goto D;
                }
            }
            throw new MyLexicalException("Лексикографическая ошибка. Строка " + SearchStartBadWord(), indexCurrentSymbol / 50, indexCurrentSymbol);
        C:
            if (currentSymbol == '0')
            {
                if (currentSymbolToken == CharToken.Number)
                {
                    ReadNextSymbol();
                    goto A;
                }
            }
            throw new MyLexicalException("Лексикографическая ошибка. Строка " + SearchStartBadWord(), indexCurrentSymbol / 50, indexCurrentSymbol);

        D:
            if (currentSymbol == '1')
            {
                if(indexCurrentSymbol + 1   < originString.Length )
                {
                    if(originString[indexCurrentSymbol+1] == ' ')
                    {
                        tokenWord = CharToken.Unknown;
                        currentSymbolToken = CharToken.Unknown;
                        RecognizeIdentifier();
                        goto Fin;
                    }
                }
                else
                {
                    tokenWord = CharToken.Unknown;
                    currentSymbolToken = CharToken.Unknown;
                    goto Fin;
                }
                if (currentSymbolToken == CharToken.Number)
                {
                    ReadNextSymbol();
                    goto E;
                }
            }
            throw new MyLexicalException("Лексикографическая ошибка. Строка " + SearchStartBadWord(), indexCurrentSymbol / 50, indexCurrentSymbol);

        E:
            if (currentSymbol == '1')
            {
                if (currentSymbolToken == CharToken.Number)
                {
                    ReadNextSymbol();
                    goto F;
                }
            }
            throw new MyLexicalException("Лексикографическая ошибка. Строка " + SearchStartBadWord(), indexCurrentSymbol / 50, indexCurrentSymbol);

        F:
            if (currentSymbol == '1')
            {
                if (currentSymbolToken == CharToken.Number)
                {
                    ReadNextSymbol();
                    goto D;
                }
            }
            throw new MyLexicalException("Лексикографическая ошибка. Строка " + SearchStartBadWord(), indexCurrentSymbol / 50, indexCurrentSymbol);

        Fin:
            return;


        }

        private static void ReadNextSymbol()
        {
            indexCurrentSymbol++;
            if (originString.Length > indexCurrentSymbol)
            {
                currentSymbol = originString[indexCurrentSymbol];
                ClassifySymbol(originString[indexCurrentSymbol]);
                if(tokenWord == CharToken.BadChar)
                {
                    throw new MyLexicalException("Лексикографическая ошибка. Строка " + SearchStartBadWord(), indexCurrentSymbol / 50, indexCurrentSymbol);
                }
            }
            else if(tokenWord == CharToken.Space)
            {
                tokenWord = CharToken.Unknown;
                currentSymbolToken= CharToken.Unknown;
                return;
            }
            else if(tokenWord != CharToken.Unknown )
            {
                throw new MyLexicalException("Лексикографическая ошибка. Строка " + SearchStartBadWord(), indexCurrentSymbol / 50 ,indexCurrentSymbol);
            }
        }

        private static string SearchStartBadWord()
        {
            return originString.Substring(indexStartWord - 1, GetIndexEndWord(originString, indexStartWord));
        }

        private static int GetIndexEndWord(string originStr, int startIndexWord)
        {
            int prom = 0;
            for (int i = startIndexWord; i < originStr.Length; i++)
            {
                if (originStr[i] == ' ')
                {
                    prom = i-1;
                    break;
                }
                prom = i;
            }
            return prom - startIndexWord + 2; // +1, тк нужно взять длину, а не количество
        }

        private static void ClassifySymbol(char v)
        {
            if (CharIsBinary(v) && CharToken.Comment != tokenWord)
            {
                currentSymbolToken = CharToken.Number;
                return;
            }
            else if (CharIsString(v) && CharToken.Comment != tokenWord)
            {
                currentSymbolToken = CharToken.Letter;
                return;
            }
            else if (v == '/')
            {
                if (previousCommentToken == CommentSymbol.unknown)
                {
                    currentSymbolToken = CharToken.Comment;
                    return;
                }
                if (previousCommentToken == CommentSymbol.symbol)
                {
                    currentSymbolToken = CharToken.Comment;
                    return;
                }
                if (previousCommentToken == CommentSymbol.star )
                {
                    currentSymbolToken = CharToken.EndComment;
                    return;
                }
            }
            else if (v == '*')
            {
                if( tokenWord != CharToken.Comment)
                {
                    tokenWord = CharToken.BadChar;
                    return;
                }
                if (previousCommentToken == CommentSymbol.slash)
                {
                    currentSymbolToken = CharToken.Comment;
                    return;
                }
                if (previousCommentToken == CommentSymbol.star)
                {
                    currentSymbolToken = CharToken.Comment;
                    return;
                }
                if (previousCommentToken == CommentSymbol.symbol)
                {
                    currentSymbolToken = CharToken.Comment;
                    return;
                }
                
            }
            else if (v == ' ' && (currentSymbolToken == CharToken.Unknown || currentSymbolToken == CharToken.EndComment))
            {
                currentSymbolToken = CharToken.Space;
                tokenWord = CharToken.Space;
                return;
            }
            else if (v == ' ' && currentSymbolToken == CharToken.Comment) 
            {
                currentSymbolToken = CharToken.Comment;
                tokenWord = CharToken.Comment;
                return;
            }
            else if (currentSymbolToken == CharToken.Comment)
            {
                currentSymbolToken = CharToken.Comment;
                tokenWord = CharToken.Comment;
                return;
            }
            else if(tokenWord == CharToken.EndComment)
            {
                currentSymbolToken = CharToken.EndComment;
                return;
            }
            else
                currentSymbolToken = CharToken.BadChar;
        }

        private static bool CharIsString(char v)
        {
            if(charsList.Contains(v))
                return true;
            return false;
        }

        private static bool CharIsBinary(char v)
        {
            if (v == '0' || v == '1')
                return true;
            return false;
        }

        private static void Inicializ(string str)
        {
            indexCurrentSymbol = -1;
            currentSymbolToken = CharToken.Unknown;
            tokenWord = CharToken.Unknown;
            currentSymbol = ' ';
            originString = str;
            indexStartWord = 0;
            previousCommentToken = CommentSymbol.unknown;
    }

        private static bool CheckString(string s)
        {
            if(string.IsNullOrEmpty(s) || string.IsNullOrWhiteSpace(s))
                return false;
            return true;
        }


    }
}
