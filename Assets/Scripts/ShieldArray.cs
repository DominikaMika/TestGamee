using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldArray : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private int numOfEnemy;

    [SerializeField]
    private float enemySpeed;

    [SerializeField]
    private float maxX;
    [SerializeField]
    private float minX;
    [SerializeField]
    private float maxZ;
    [SerializeField]
    private float minZ;

    private List<GameObject> enemies = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        for (int n = 0; n < numOfEnemy; n++)
        {
            float dx = Random.Range(minX, maxX);
            float dz = Random.Range(minZ, maxZ);

            GameObject obj = Instantiate(enemyPrefab, new Vector3(dx, 1, dz), Quaternion.identity);
            enemies.Add(obj);

        }

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < numOfEnemy; i++)
        {
            float step = Time.deltaTime * enemySpeed;
            Vector3 enemyPos = enemies[i].transform.position;
            Vector3 playerPos = player.transform.position;
            enemies[i].transform.position = Vector3.MoveTowards(enemyPos, playerPos, step);
        }
    }
}
