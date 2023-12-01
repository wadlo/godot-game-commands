public static class AstPrinter
{
    public static string Print(AstNode node)
    {
        if (node is CommandNode commandNode)
        {
            string argumentsString = "";
            foreach (AstNode astNode in commandNode.Arguments)
            {
                argumentsString += ", " + astNode.ToString();
            }
            string arguments = string.Join(", ", argumentsString);
            return $"{commandNode.CommandName}({arguments})";
        }
        else
        {
            return "";
        }
    }
}
