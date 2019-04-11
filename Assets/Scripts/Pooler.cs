using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;

    }

    [SerializeField]
    public int poolSizes;

    public List<Pool> pools;
    public List<GameObject> enemiesOnField;
    [SerializeField]
    private int enemiesDown;
    public Dictionary<string, Queue<GameObject>> poolDict;

    #region singleton
    public static Pooler instance;

    public int EnemiesDown { get => enemiesDown; set => enemiesDown = value; }

    private void Awake()
    {
        instance = this;
    } 
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        poolDict = new Dictionary<string, Queue<GameObject>>();
        EnemiesDown = 0;

        //Llenar el pool.
        foreach (Pool pool in pools)
        {
            int s = poolSizes;
            if (pool.tag == "Bullet" || pool.tag == "EBullet")
                poolSizes = 50;     //siempre instanciar 50 balas
            else
                poolSizes = s;      //recuperar el valor anterior

            Queue<GameObject> objPool = new Queue<GameObject>();
            for (int i = 0; i < poolSizes; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objPool.Enqueue(obj);
            }
            poolDict.Add(pool.tag, objPool);

            poolSizes = s;
        }

        //spawnear los enemigos
        SpawnEnemies();
    }

    public void Update()
    {
        if (enemiesDown >= enemiesOnField.Count)
        {
            SpawnEnemies();
        }
    }

    private void SpawnEnemies()
    {
        for (int i = 0; i < poolSizes; i++)
        {
            enemiesOnField.Add(Spawn("Normal", GenerateRandomPosition()));
            enemiesOnField.Add(Spawn("Kami", GenerateRandomPosition())); ;
            enemiesOnField.Add(Spawn("Coward", GenerateRandomPosition())); 
        }
            EnemiesDown= 0;
    }

    public GameObject Spawn(string tag, Vector3 position)
    {
        GameObject chosen = poolDict[tag].Dequeue();
        if (!chosen.active)
        {
            chosen.SetActive(true); 
        }
        chosen.transform.position = position;

        poolDict[tag].Enqueue(chosen);

        return chosen;
    }

    public void PutAway(GameObject self)
    {
        self.SetActive(false);

    }

    public Vector3 GenerateRandomPosition()
    {
        Vector3 pos = new Vector3();

        pos.x = Random.Range(0f, 30f);
        pos.y = 1f;
        pos.z = Random.Range(-10f, 28f);

        return pos;
    }
}
