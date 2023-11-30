using System.Collections.Generic;
using Godot;

public class TestAst
{
    public static void TestSpawnCommand()
    {
        string input = "/sum(sum(1,2), -10)";
        Lexer lexer = new Lexer(input);
        List<Token> tokens = new List<Token>();
        Token token;
        do
        {
            token = lexer.NextToken();
            tokens.Add(token);
            GD.Print($"{token.Type}: {token.Lexeme}");
        } while (token.Type != TokenType.EOF);

        Parser parser = new Parser(tokens);
        AstNode ast = parser.Parse();

        string astString = AstPrinter.Print(ast);
        GD.Print("Abstract Syntax Tree:");
        GD.Print(astString);

        GD.Print("Evaluates to:");
        GD.Print(ast.Evaluate());
    }
}
