public class Sequence : Composite
{
    protected override bool ValueToBreak { get { return false; } }

    private bool success;

    public override bool Execute()
    {
        success = false;
        foreach (Task task in children)
        {
            if (task.Execute())
                success = true;
            else
            {
                success = false;
                break;
            }
        }
        return success;
    }
}