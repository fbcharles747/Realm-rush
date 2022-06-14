using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{

    [SerializeField]List<WayPoint> path=new List<WayPoint>();
    [SerializeField][Range(0,5f)] float travelSpeed=0.4f;
    Enemy enemy;

     
    // Start is called before the first frame update
    void OnEnable()
    {
        Debug.Log("start");
        
        findPath();
        returnToStart();
        StartCoroutine(followPath());
        
    }
    void Start()
    {
        enemy=GetComponent<Enemy>();
    }

    void findPath()
    {
        path.Clear();
        GameObject parentPath=GameObject.FindGameObjectWithTag("path");
        foreach (Transform child in parentPath.transform)
        {
            WayPoint wayPoint=child.GetComponent<WayPoint>();
            if(wayPoint!=null)
            {
                path.Add(wayPoint);
            }
            
        }
        
    }
    void returnToStart()
    {
        transform.position=path[0].transform.position;
    }

    IEnumerator followPath()
    {
        Vector3 startPosition;
        Vector3 endPosition;
        float travelPercentage;
        foreach (WayPoint wayPoint in path)
        {
            startPosition=transform.position;
            endPosition=wayPoint.transform.position;
            travelPercentage=0f;
            transform.LookAt(endPosition);//facing the end point

            //walking from point to point
            while(travelPercentage<1f)
            {
                travelPercentage+=Time.deltaTime*travelSpeed;
                transform.position=Vector3.Lerp(startPosition,endPosition,travelPercentage);
                yield return new WaitForEndOfFrame();
            }
            
            
        }
        enemy.stealGold();
        gameObject.SetActive(false);
        
        
    }

    
}
