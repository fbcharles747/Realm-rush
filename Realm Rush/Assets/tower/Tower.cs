using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] int cost=75;
    public bool createTower(Tower tower,Vector3 position)
    {
        Bank bank=FindObjectOfType<Bank>();
        if(bank==null){
            return false;
        }

        if(bank.currentGold>=cost)
        {
            Instantiate(gameObject,position,Quaternion.identity);
            bank.withDraw(cost);
            return true;
        }
        return false;
    }
    
}
