using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public abstract class Character : MonoBehaviour
{
    [SerializeField]
    private float maxHP;

    [SerializeField]
    private EnemyBullet eBullet;

    [SerializeField]
    private float shootForce = 20F;

    [SerializeField]
    private Transform bulletSpawnPosition;

    [SerializeField]
    private float hp;

    public float HP
    {
        get { return hp; }
        protected set { hp = value; }
    }

    public float ShootForce { get { return shootForce; } }

    public Transform BulletSpawnPosition { get => bulletSpawnPosition; set => bulletSpawnPosition = value; }

    public void ModifyHP(float delta)
    {
        HP += delta;

        if (HP <= 0F)
        {
            OnDeath();
        }
    }

    protected virtual void OnDeath()
    {
        Pooler.instance.PutAway(gameObject);
        Pooler.instance.EnemiesDown++;
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        HP = maxHP;
    }
    /*
    public void SpawnBullet()
    {
        if (eBullet != null && BulletSpawnPosition != null)
        {
            Instantiate<Bullet>(eBullet, BulletSpawnPosition.position, transform.rotation).Shoot(this);
        }
    }*/
}