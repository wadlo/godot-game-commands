using System.Collections;
using System.Collections.Generic;
using System;
using Godot;

public class Parser
{
    private readonly List<Token> tokens;
    private int current = 0;

    public Parser(List<Token> tokens)
    {
        this.tokens = tokens;
    }

    public AstNode Parse()
    {
        return ParseExpression();
    }

    private AstNode ParseExpression()
    {
        Token token = Advance();
        switch (token.Type)
        {
            case TokenType.Command:
                return ParseCommand(token);
            case TokenType.Number:
                return new NumberNode(float.Parse(token.Lexeme));
            default:
                throw new Exception($"Unexpected token: {token.Lexeme}");
        }
    }

    private AstNode ParseCommand(Token token)
    {
        Token nextToken = Advance();
        List<AstNode> arguments;
        if (nextToken.Type == TokenType.LeftParen)
        {
            // Parse arguments for /spawn
            arguments = ParseArgumentList();
        }
        else
        {
            // No arguments
            arguments = new List<AstNode>();
        }
        return new CommandNode(token.Lexeme, arguments);
    }

    private List<AstNode> ParseArgumentList()
    {
        List<AstNode> arguments = new List<AstNode>();
        while (Peek().Type != TokenType.RightParen)
        {
            AstNode argument = ParseExpression();
            arguments.Add(argument);
            if (Peek().Type == TokenType.Comma)
            {
                Advance(); // Consume the comma
            }
            else if (Peek().Type != TokenType.RightParen)
            {
                throw new Exception("Expected ',' or ')' in argument list");
            }
        }
        Consume(TokenType.RightParen, "Expected ')' after argument list");
        return arguments;
    }

    private Token Advance()
    {
        if (!IsAtEnd())
        {
            current++;
        }
        return Previous();
    }

    private bool IsAtEnd()
    {
        return Peek().Type == TokenType.EOF;
    }

    private Token Peek()
    {
        return tokens[current];
    }

    private Token Previous()
    {
        return tokens[current - 1];
    }

    private void Consume(TokenType type, string errorMessage)
    {
        if (Peek().Type == type)
        {
            Advance();
        }
        else
        {
            throw new Exception(errorMessage);
        }
    }
}
