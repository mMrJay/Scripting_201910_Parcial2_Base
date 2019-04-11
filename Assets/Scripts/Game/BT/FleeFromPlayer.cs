using UnityEngine;

public class FleeFromPlayer : Task
{
    [SerializeField]
    private float speed;

    public override bool Execute()
    {
        Vector3 playerPos = GameObject.Find("Player").transform.position;

        transform.LookAt(playerPos);
        
        transform.position += transform.forward * Time.deltaTime * speed *-1;

        return true;
    }
}