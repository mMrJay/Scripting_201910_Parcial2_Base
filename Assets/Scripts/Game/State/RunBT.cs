using UnityEngine;

public class RunBT : State
{
    [SerializeField]
    protected Root btRoot;

    [SerializeField]
    private Color actingColor;

    public override void Execute()
    {
        GetComponent<Renderer>().material.color = actingColor;
        if (btRoot != null)
        {
            btRoot.Execute();
        }
        if (CheckDistanceToPlayer() >= GetComponent<Idle>().WarningDistance)
        {
            print("aaaaaaaaaaaaa");
            Yo.SetNewState(NextState);
        }
    }
}