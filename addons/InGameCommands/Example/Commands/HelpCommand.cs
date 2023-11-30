using System.Collections.Generic;
using Godot;

public class HelpCommand : Command
{
    public override string GetName()
    {
        return "help";
    }

    public override List<CommandArgument> GetArguments()
    {
        return new List<CommandArgument>();
    }

    public HelpCommand() { }

    public override Variant Calculate(List<Variant> arguments)
    {
        return "Help isn't yet implemented";
    }
}
