using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllEnemyTypeContainer : MonoBehaviour
{
    [SerializeField] BaseEnemy[] allEnemyTypes;

    public static AllEnemyTypeContainer Instance{get;private set;}

    private void Awake() {
        if(Instance != null)
        {
            Destroy(this);
            return;
        }
        Instance = this;
    }


    public BaseEnemy[] GetAllEnemyTypes()
    {
        return allEnemyTypes;
    }
}
