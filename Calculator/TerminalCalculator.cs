using System;
using System.Collections.Generic;
using System.Linq;

namespace Calculator
{
    public class TerminalCalculator
    {
        public long Eval(string input)
        {
            input = input.Trim().Replace(" ", string.Empty);
            ValidateInput(input);

            var tokens = Tokenizer.Parse(input)
                .Where(t => t.IsMathOperator || t.Type == TokenType.Number)
                .ToList();

            var s = new Stack<Token>();
            foreach (var t in tokens)
            {
                if (t.IsMathOperator)
                {
                    s.Push(t);
                }
                else
                {
                    s.Push(t);
                    bool canProcess = true;
                    while (canProcess)
                    {
                        var t1 = s.Pop();
                        var t2 = s.Pop();
                        if (t2.Type == TokenType.Number)
                        {
                            var operation = s.Pop();
                            var r = GetCalculation(t1, t2, operation);
                            s.Push(r);

                            if (s.Count == 1)
                            {
                                canProcess = false;
                            }
                        }
                        else
                        {
                            s.Push(t2);
                            s.Push(t1);
                            canProcess = false;
                        }
                    }
                }
            }

            return s.Pop().Value.Value;
        }

        private Token GetCalculation(Token t1, Token t2, Token op)
        {
            Token t = null;
            switch (op.Type)
            {
                case TokenType.Add:
                    t = new Token(TokenType.Number, t1.Value + t2.Value);
                    break;
                case TokenType.Mult:
                    t = new Token(TokenType.Number, t1.Value * t2.Value);
                    break;
                case TokenType.Div:
                    t = new Token(TokenType.Number, t2.Value / t1.Value);
                    break;
            }

            return t;
        }

        private void ValidateInput(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentException("Input string can not be empty.");
            }

            for (var i = 0; i < input.Length; i++)
            {
                if (input[i] == '(' || input[i] == ')' || input[i] ==',' || input[i] == '-')
                {
                    continue;
                }
                else
                {
                    if (!char.IsLetterOrDigit(input[i]))
                    {
                        throw new ArgumentException("Input string contains invalid characters.");
                    }
                }
            }

            // TODO: to add validation for unsupported operations.
        }
    }
}
