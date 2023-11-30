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

    public CommandArgument(string name, CommandArgumentType type)
    {
        this.name = name;
        this.type = type;
    }
}
