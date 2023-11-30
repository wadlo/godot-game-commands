using System.Collections.Generic;
using Godot;

public partial class HelpCommand : Command
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
        if (arguments.Count == 0)
        {
            string returnValue = "Commands: \n";
            foreach (Command command in InGameCommands.instance.GetCommands())
            {
                returnValue += "   " + command.GetName() + "\n";
            }
            returnValue += "Type /help [command] for more help on a specific command";
            return returnValue;
        }
        else
        {
            return "Not yet supported";
        }
    }
}
