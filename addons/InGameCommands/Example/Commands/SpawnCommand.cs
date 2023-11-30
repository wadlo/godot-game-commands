using System.Collections.Generic;
using Godot;

public class SpawnCommand : Command
{
    public override string GetName()
    {
        return "spawn";
    }

    public override List<CommandArgument> GetArguments()
    {
        return new List<CommandArgument>()
        {
            new CommandArgument("object", CommandArgument.CommandArgumentType.STRING),
            new CommandArgument("x", CommandArgument.CommandArgumentType.NUMBER)
        };
    }

    public override Variant Calculate(List<Variant> arguments)
    {
        GD.Print("Ran calculate inside 'spawn'");
        return 1;
    }
}
