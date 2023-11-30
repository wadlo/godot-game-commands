using Godot;

public class NumberNode : AstNode
{
    public float Value { get; }

    public NumberNode(float value)
    {
        Value = value;
    }

    public override Variant Evaluate()
    {
        return Value;
    }
}
