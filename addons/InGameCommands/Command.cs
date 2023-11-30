using System.Collections.Generic;
using Godot;
using Godot.Collections;
using Godot.NativeInterop;
using Microsoft.VisualBasic;

public abstract class Command
{
    public abstract string GetName();

    public abstract List<CommandArgument> GetArguments();

    public abstract Variant Calculate(List<Variant> arguments);
}
