using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    [SerializeField] bool isPlaceable;
    [SerializeField] Tower towerPrefab;

    public bool IsPlaceable{get{return isPlaceable;}}//IsPlaceable as a property


    // Start is called before the first frame update
    private void OnMouseDown() 
    {
        if(isPlaceable)
        {
            bool isPlaced = towerPrefab.createTower(towerPrefab,transform.position);
            isPlaceable=!isPlaced;
        }
        
        
    }
}
