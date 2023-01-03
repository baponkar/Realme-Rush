using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;

[ExecuteAlways]
public class CoordinateLabeler : MonoBehaviour
{
    TextMeshPro label;
    Vector2Int pos;

    Waypoint waypoint;
    public Color labelDefaultColor = Color.white;
    public Color labelBlockedColor = Color.grey;

    void Awake()
    {
        label = GetComponentInChildren<TextMeshPro>();
        waypoint = GetComponent<Waypoint>();

        label.enabled = false;
    }
    

    
    void Update()
    {
        //In Play Game Mode
        
        if (!Application.isPlaying)
        {
            label.enabled = true;
            DisplayCurrentCoordinate();
            UpdateObjectName();
        }

        ColorCoordinate();
        ToggleLabel();
    }

    void DisplayCurrentCoordinate()
    {
        pos.x = Mathf.RoundToInt(transform.position.x/EditorSnapSettings.move.x); //as we change snap settings into 10
        pos.y = Mathf.RoundToInt(transform.position.z/EditorSnapSettings.move.z); //as we change snap settings into 10
        label.text = pos.x.ToString() + " , " + Mathf.RoundToInt(pos.y).ToString();

    }

    void UpdateObjectName()
    {
        //change name
        transform.name = pos.x.ToString() + " , " + pos.y.ToString();
    }

    void ColorCoordinate()
    {
        if (waypoint.IsPlaceable)
        {
            label.color = labelDefaultColor;
        }
        else
        {
            label.color = labelBlockedColor;
        }
    }

    void ToggleLabel()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            label.enabled = !label.enabled;
        }
    }
}
