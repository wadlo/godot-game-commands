using System.Collections.Generic;
using Godot;

public class CommandNode : AstNode
{
    public string CommandName { get; }
    public List<AstNode> Arguments { get; }

    public CommandNode(string commandName, List<AstNode> arguments)
    {
        CommandName = commandName;
        Arguments = arguments;
    }

    public override Variant Evaluate()
    {
        // First evaluate the parameters.
        List<Variant> evaluatedParameters = new List<Variant>();
        foreach (AstNode node in Arguments)
        {
            evaluatedParameters.Add(node.Evaluate());
        }

        if (InGameCommands.instance == null)
        {
            GD.Print(
                "Error: Your scene doesn't have an InGameCommand node! Try adding the example InGameCommands.tscn to your scene."
            );
        }
        foreach (Command command in InGameCommands.instance.GetCommands())
        {
            if (command.GetName() == CommandName)
            {
                return command.Calculate(evaluatedParameters);
            }
        }
        return 10;
    }
}
