using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrojanEnemy : BaseEnemy
{
    private void Start() {
        WormEnemy.AddTrojanEnemyToList(this);
    }

    private void OnDestroy() {
        WormEnemy.RemoveTrojanEnemyFromList(this);
    }    
}
