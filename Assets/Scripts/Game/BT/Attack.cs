using UnityEngine;

public class Attack : Task
{
    [SerializeField]
    private float tDisparo;
    private float t;

    private bool canShoot;

    
    public override bool Execute()
    {
        Vector3 playerPos = GameObject.Find("Player").transform.position;
        transform.LookAt(playerPos);

        t += Time.deltaTime;
        if (t >= tDisparo)
        {
            GameObject bullet = Pooler.instance.Spawn("EBullet", GetComponent<AICharacter>().BulletSpawnPosition.position);
            bullet.GetComponent<Rigidbody>().velocity = Vector3.zero;
            bullet.GetComponent<Rigidbody>().AddForce(transform.forward * GetComponent<AICharacter>().ShootForce, ForceMode.Impulse);
            t = 0;
        }
        print(t);
        return true;
    }
}