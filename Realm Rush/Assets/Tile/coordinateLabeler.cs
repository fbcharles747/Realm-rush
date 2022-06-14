using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteAlways]
[RequireComponent(typeof(TextMeshPro))]
public class coordinateLabeler : MonoBehaviour
{
    
    TextMeshPro label;
    Vector2Int coordinate=new Vector2Int();
    [SerializeField] Color defaultColor=Color.white;
    [SerializeField] Color blockColor=Color.grey;

    WayPoint wayPoint;

    
    private void Awake() 
    {
        label=GetComponent<TextMeshPro>();
        displayCoordinate();
        wayPoint=GetComponentInParent<WayPoint>();
        label.enabled=false;

    }
    void Update()
    {
        if(!Application.isPlaying)
        {
            displayCoordinate();
            updateName();
            label.enabled=true;
        }
        colorCoordinate();
        toggleWayPoint();
        
    }
    void toggleWayPoint()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            label.enabled=!label.enabled;
        }
    }
    void colorCoordinate()
    {
        if(wayPoint.IsPlaceable)
        {
            label.color=defaultColor;

        }else{
            label.color=blockColor;
        }

    }

    void displayCoordinate()
    {
        coordinate.x=Mathf.RoundToInt(transform.parent.position.x/UnityEditor.EditorSnapSettings.move.x);
        coordinate.y=Mathf.RoundToInt(transform.parent.position.z/UnityEditor.EditorSnapSettings.move.z);
        label.text=coordinate.ToString();
        
    }
    void updateName()
    {
        transform.parent.name=coordinate.ToString();
    }
    
}
