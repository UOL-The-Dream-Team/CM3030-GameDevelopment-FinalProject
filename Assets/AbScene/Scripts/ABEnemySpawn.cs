using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ABEnemySpawn : MonoBehaviour
{
    public GameObject enemy;

    // Update is called once per frame
    void Update()
    {
        if (Random.Range(1, 1000) > 998)
        {
            GameObject newEnemy = Instantiate(enemy, transform.position, Quaternion.identity);
        }
    }
}
