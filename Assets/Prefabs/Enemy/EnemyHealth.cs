using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoint = 5;

    [Tooltip("When enemy dies this amount added to the maxHit")]
    [SerializeField] int difficultyRamp = 1;
    int currentHitPoint = 0;
    
    Enemy enemy;
    void OnEnable()
    {
        currentHitPoint = maxHitPoint;
    }

    void Start()
    {
        enemy = GetComponent<Enemy>();
    }
    
    void Update()
    {
        
    }

    

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    void ProcessHit()
    {
        currentHitPoint--;
        //Debug.Log("Hited!");

        if(currentHitPoint <= 0)
        {
            // Destroy(this.gameObject);
            gameObject.SetActive(false);
            enemy.RewardGold();
            maxHitPoint += difficultyRamp;
        }
    }
}
