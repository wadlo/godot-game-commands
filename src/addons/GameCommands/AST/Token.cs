using System;
using System.Collections.Generic;
using System.Linq;

public class Token
{
    public TokenType Type { get; }
    public string Lexeme { get; }

    public Token(TokenType type, string lexeme)
    {
        Type = type;
        Lexeme = lexeme;
    }
}

public enum TokenType
{
    // Command such as "help" or "spawn"
    Command,
    Number,
    Comma,
    LeftParen,
    RightParen,
    EOF,

    // Used to represent something not supported by the tokenizer
    Error,
}
