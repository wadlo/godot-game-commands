using System;
using System.Collections.Generic;
using Godot;

public partial class SpawnCommand : Command
{
    [Export]
    public Godot.Collections.Array<PackedScene> scenes = new Godot.Collections.Array<PackedScene>();

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
        PackedScene scene = null;
        string sceneName = arguments[0].As<string>();

        foreach (PackedScene packedScene in scenes)
        {
            if (packedScene.ResourceName.ToLower() == sceneName.ToLower())
            {
                scene = packedScene;
            }
        }

        if (scene != null)
        {
            var parent = GameCommands.instance.GetTree().Root;
            var instantiated = scene.Instantiate();
            parent.AddChild(instantiated);
            return instantiated;
        }

        return 0;
    }
}
