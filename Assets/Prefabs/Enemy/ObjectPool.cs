using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    /*
     * Create Object and after reach in the path end its not destroy instead
     * put back in start
     */

    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float spawnTime = 2f;

    [SerializeField] int poolSize = 5;

    GameObject[] pool;

    void Awake()
    {
        PopulatePool();
    }

    void PopulatePool()
    {
        pool = new GameObject[poolSize];

        for(int i=0; i<pool.Length; i++)
        {
            pool[i] = Instantiate(enemyPrefab, transform);
            pool[i].SetActive(false);
        }
    }

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    
    IEnumerator SpawnEnemy()
    {
        while(true)
        {
            EnabledObjectInPool();
            yield return new WaitForSeconds(spawnTime);
        }
    }

    void EnabledObjectInPool()
    {
            for(int i=0;i<pool.Length; i++)
            {
                if(pool[i].activeInHierarchy == false)
                {
                    pool[i].SetActive(true);
                    return;
                }
                
            }
    }
}
