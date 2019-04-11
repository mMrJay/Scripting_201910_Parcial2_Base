using UnityEngine;

public class Warning : State
{
    [SerializeField]
    private Color warningColor;
    [SerializeField]
    private float actDistance;

    public override void Execute()
    {
        GetComponent<Renderer>().material.color = warningColor;
        Vector3 playerPos = GameObject.Find("Player").transform.position;

        transform.LookAt(playerPos);
        if (CheckDistanceToPlayer() <= actDistance)
        {
            print("cambio a Act");
            Yo.SetNewState(NextState);
        }
    }
}
