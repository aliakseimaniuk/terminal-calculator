using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    public class Tokenizer
    {
        public static List<Token> Parse(string input)
        {
            var lst = new List<Token>();
            var current = new StringBuilder();

            for (var i = 0; i < input.Length; i++)
            {
                current.Append(input[i]);

                switch (current.ToString())
                {
                    case "add":
                        lst.Add(new Token(TokenType.Add));
                        current.Clear();
                        break;

                    case "mult":
                        lst.Add(new Token(TokenType.Mult));
                        current.Clear();
                        break;

                    case "div":
                        lst.Add(new Token(TokenType.Div));
                        current.Clear();
                        break;

                    case "(":
                        lst.Add(new Token(TokenType.LeftParenthesis));
                        current.Clear();
                        break;

                    case ")":
                        lst.Add(new Token(TokenType.RightParenthesis));
                        current.Clear();
                        break;

                    case ",":
                        lst.Add(new Token(TokenType.Comma));
                        current.Clear();
                        break;
                }

                if (current.ToString().EndsWith(","))
                {
                    var s = current.ToString().Replace(",", string.Empty);
                    if (IsNumber(s))
                    {
                        lst.Add(new Token(TokenType.Number, long.Parse(s)));
                        lst.Add(new Token(TokenType.Comma));
                        current.Clear();
                    }
                }

                if (current.ToString().EndsWith(")"))
                {
                    var s = current.ToString().Replace(")", string.Empty);
                    if (IsNumber(s))
                    {
                        lst.Add(new Token(TokenType.Number, long.Parse(s)));
                        lst.Add(new Token(TokenType.RightParenthesis));
                        current.Clear();
                    }
                }
            }

            return lst;
        }

        private static bool IsNumber(string s)
        {
            return long.TryParse(s, out _);
        }
    }
}
