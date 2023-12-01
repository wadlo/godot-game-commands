using System;
using System.Collections.Generic;
using Godot;

public partial class SumCommand : Command
{
    public override string GetName()
    {
        return "sum";
    }

    public override Variant Calculate(List<Variant> arguments)
    {
        float sum = 0;
        foreach (Variant argument in arguments)
        {
            sum += argument.As<float>();
        }
        ;
        return sum;
    }

    public override List<CommandArgument> GetArguments()
    {
        return new List<CommandArgument>()
        {
            new CommandArgument("number1", CommandArgument.CommandArgumentType.NUMBER),
            new CommandArgument("number2", CommandArgument.CommandArgumentType.NUMBER)
        };
    }
}
