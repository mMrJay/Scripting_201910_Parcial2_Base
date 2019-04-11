using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnemyBullet : MonoBehaviour
{
    [SerializeField]
    private float damage = 10F;

    private Character instigator;

    private Rigidbody myRigidbody;

    public Character Instigator
    {
        get { return instigator; }
        set { instigator = value; }
    }

    public void Shoot(Character character)
    {
        Instigator = character;
        myRigidbody.AddForce(transform.forward * character.ShootForce, ForceMode.Impulse);
    }

    private void Awake()
    {
        myRigidbody = GetComponent<Rigidbody>();
        Invoke("DestroyObject", 10F);
    }

    private void DestroyObject()
    {
        Pooler.instance.PutAway(gameObject);
    }

    private void OnDestroy()
    {
        CancelInvoke();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Character character = collision.gameObject.GetComponent<Character>();

            if (character != null && instigator != character)
            {
                character.ModifyHP(damage * -1);
            }
        }

        if (collision.gameObject.Equals(instigator.gameObject))
        {
            Pooler.instance.PutAway(gameObject);
        }
    }


}