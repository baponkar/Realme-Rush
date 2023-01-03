using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField]  List<Waypoint> path = new List<Waypoint>();
    [SerializeField] [Range(0,5f)] float speed = 1f;

    Vector3 startPosition;
    Vector3 endPosition;

    Enemy enemy;

    void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    void OnEnable()
    {
        FindPath();
        ReturnToStart();
        StartCoroutine(FollowPath());
    }

    
    

    void ReturnToStart()
    {
        transform.position = path[0].transform.position;
    }

    void FindPath()
    {
        path.Clear();
        GameObject[] paths = GameObject.FindGameObjectsWithTag("Path");
        foreach (var obj in paths)
        {
            path.Add(obj.GetComponent<Waypoint>());
        }
    }

    IEnumerator FollowPath()
    {
        foreach(var waypoint in path)
        {

            startPosition = transform.position;
            endPosition =  waypoint.transform.position;
            float  travelPercent = 0;

            transform.LookAt(waypoint.transform.position);

            while(travelPercent < 1f)
            {
                travelPercent += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(startPosition,endPosition, travelPercent);
                yield return new WaitForEndOfFrame();
            }
        }
        //Destroy(gameObject);
        enemy.StealGold();
        gameObject.SetActive(false);
    }

    void PrintWaypointName()
    {
        foreach(var waypoint in path)
        {
            Debug.Log(waypoint.name);
        }
    }
}
