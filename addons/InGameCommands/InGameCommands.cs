using Godot;
using Godot.Collections;
using System;
using System.Collections.Generic;

public abstract partial class InGameCommands : ColorRect
{
    [Export]
    private LineEdit commandLine;

    [Export]
    private Label suggestion;

    [Export]
    private string emptySuggestion = "Type /help for a list of commands";

    [Export]
    private string commandPrefix = "/";

    [Export]
    public Label outputLabel;

    private Array<Command> commands;

    Array<string> suggestions = new Array<string>();

    public static InGameCommands instance;

    public override void _Ready()
    {
        instance = this;
        commandLine.TextChanged += (newText) =>
        {
            Refresh(newText);
        };
        commandLine.TextSubmitted += (string text) =>
        {
            TextSubmitted(text);
        };

        // So that the starting message is updated
        Refresh(commandLine.Text);
    }

    public void TextSubmitted(string text)
    {
        outputLabel.Text += "\n" + text + "\n";
        outputLabel.Text += EvaluateString(text).AsString().Replace("\n", "\n   ");
        commandLine.Text = "";
    }

    public void Refresh(string newText)
    {
        if (newText.StartsWith(commandPrefix))
        {
            RecalculateSuggestions(newText.Substr(commandPrefix.Length, newText.Length));
        }
        suggestion.Text = GetSuggestion();
    }

    public void RecalculateSuggestions(string currentWord)
    {
        Array<string> allPossibleSuggestions = GetAllPossibleSuggestions();

        suggestions = FilterToMatchAutocomplete(allPossibleSuggestions, currentWord);
    }

    public Array<string> GetAllPossibleSuggestions()
    {
        Array<string> allPossibleSuggestions = new Array<string>();
        foreach (Command command in GetCommands())
        {
            allPossibleSuggestions.Add(command.GetName());
        }
        return allPossibleSuggestions;
    }

    public Array<string> FilterToMatchAutocomplete(
        Array<string> possibleSuggestions,
        string currentWord
    )
    {
        Array<string> matchingSuggestions = new Array<string>();
        foreach (string possibleSuggestion in possibleSuggestions)
        {
            if (possibleSuggestion.StartsWith(currentWord))
            {
                matchingSuggestions.Add(possibleSuggestion);
            }
        }
        return matchingSuggestions;
    }

    public string GetSuggestion()
    {
        if (commandLine.Text == "")
        {
            return emptySuggestion;
        }
        if (suggestions.Count > 0)
        {
            if (commandLine.Text.StartsWith(commandPrefix))
            {
                return commandPrefix + suggestions[0];
            }
        }

        return "";
    }

    public Variant EvaluateString(string input)
    {
        Lexer lexer = new Lexer(input);
        List<Token> tokens = new List<Token>();
        Token token;
        do
        {
            token = lexer.NextToken();
            tokens.Add(token);
        } while (token.Type != TokenType.EOF);

        Parser parser = new Parser(tokens);
        AstNode ast = parser.Parse();

        return ast.Evaluate();
    }

    public Array<Command> GetCommands()
    {
        // Cache the commands
        if (commands == null)
        {
            commands = new Array<Command>();
            foreach (Node child in GetChildren())
            {
                if (child is Command)
                {
                    commands.Add((Command)child);
                }
            }
        }

        return this.commands;
    }
}
