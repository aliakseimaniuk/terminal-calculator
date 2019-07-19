namespace Calculator
{
    public class Token
    {
        public Token()
        {
        }

        public Token(TokenType type, long? value = null)
        {
            Type = type;
            Value = value;
        }

        public TokenType Type { get; set; }

        public long? Value { get; set; }

        public bool IsMathOperator
        {
            get
            {
                return Type == TokenType.Add || Type == TokenType.Mult || Type == TokenType.Div;
            }
        }
    }
}
