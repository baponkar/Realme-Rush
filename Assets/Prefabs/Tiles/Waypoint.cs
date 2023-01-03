using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] Tower towerPrefab;
    [SerializeField] bool placeabale = true;

    public bool IsPlaceable
    {
        get
        {
            return placeabale;
        }
    }

    private void OnMouseDown()
    {
        if(placeabale)
        {
            bool isPlaced = towerPrefab.CreateTower(towerPrefab, transform.position);
            //Instantiate(towerPrefab,transform.position,Quaternion.identity);
            placeabale = !isPlaced;
        }
    }
}
