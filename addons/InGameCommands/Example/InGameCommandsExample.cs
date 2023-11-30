using System.Collections.Generic;
using System.Xml.XPath;
using Godot;

public partial class InGameCommandsExample : InGameCommands
{
    public override void _Ready()
    {
        base._Ready();
        TestAst.TestSpawnCommand();
    }

    public override List<Command> GetCommands()
    {
        var commands = new List<Command>
        {
            new HelpCommand(),
            new SpawnCommand(),
            new SumCommand()
        };
        return commands;
    }
}
