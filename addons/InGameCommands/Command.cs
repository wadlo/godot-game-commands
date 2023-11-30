using System.Collections.Generic;
using Godot;
using Godot.Collections;
using Godot.NativeInterop;
using Microsoft.VisualBasic;

public abstract partial class Command : Node
{
    public abstract string GetName();

    public abstract List<CommandArgument> GetArguments();

    public abstract Variant Calculate(List<Variant> arguments);
}
