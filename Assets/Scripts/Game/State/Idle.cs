using UnityEngine;

public class Idle : State
{
    [SerializeField]
    private Color idleColor;

    [SerializeField]
    private float warningDistance;
    public float WarningDistance { get => warningDistance; }

    public override void Execute()
    {
        GetComponent<Renderer>().material.color = idleColor;
        if (CheckDistanceToPlayer() <= WarningDistance)
        {
            print("cambio a warning");
            Yo.SetNewState(NextState);
        }  
    }
}