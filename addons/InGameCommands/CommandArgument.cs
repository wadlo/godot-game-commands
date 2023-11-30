using System.Collections.Generic;

public class CommandArgument
{
    public enum CommandArgumentType
    {
        STRING,
        NUMBER,
        BOOL
    }

    string name;
    CommandArgumentType type;
    List<string> autocompleteValues;

    public CommandArgument(
        string name,
        CommandArgumentType type,
        List<string> autocompleteValues = null
    )
    {
        this.name = name;
        this.type = type;
        this.autocompleteValues = autocompleteValues;
    }
}
