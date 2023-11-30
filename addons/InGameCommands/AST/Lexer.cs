public class Lexer
{
    private readonly string input;
    private int position = 0;

    public Lexer(string input)
    {
        this.input = input;
    }

    public Token NextToken()
    {
        while (position < input.Length && char.IsWhiteSpace(input[position]))
        {
            position++;
        }

        if (position >= input.Length)
        {
            return new Token(TokenType.EOF, "");
        }

        char currentChar = input[position];
        position++;

        switch (currentChar)
        {
            case '/':
                position++;
                return new Token(TokenType.Command, ReadCommand());
            case '(':
                return new Token(TokenType.LeftParen, "(");
            case ')':
                return new Token(TokenType.RightParen, ")");
            case ',':
                return new Token(TokenType.Comma, ",");
            case '-':
                if (position < input.Length && char.IsDigit(input[position]))
                {
                    return new Token(TokenType.Number, ReadNumber(currentChar));
                }
                else
                {
                    return new Token(TokenType.Error, ReadError(currentChar));
                }
            default:
                if (char.IsDigit(currentChar))
                {
                    return new Token(TokenType.Number, ReadNumber(currentChar));
                }
                else if (char.IsLetter(currentChar))
                {
                    return new Token(TokenType.Command, ReadCommand());
                }
                else
                {
                    return new Token(TokenType.Error, ReadError(currentChar));
                }
        }
    }

    private string ReadCommand(string prepend = "")
    {
        int start = position - 1;
        while (position < input.Length && char.IsLetter(input[position]))
        {
            position++;
        }
        return prepend + input.Substring(start, position - start);
    }

    private string ReadNumber(char firstDigit)
    {
        int start = position - 1;
        while (position < input.Length && char.IsDigit(input[position]))
        {
            position++;
        }
        return firstDigit + input.Substring(start + 1, position - start - 1);
    }

    private string ReadError(char firstChar)
    {
        int start = position - 1;
        while (position < input.Length)
        {
            position++;
        }

        return firstChar + input.Substring(start + 1, position - start - 1);
    }
}
