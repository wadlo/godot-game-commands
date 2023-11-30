using System.Collections.Generic;
using Godot;

public class AstEvaluator
{
    public static Variant Evaluate(CommandNode commandNode)
    {
        return commandNode.Evaluate();
    }
}
