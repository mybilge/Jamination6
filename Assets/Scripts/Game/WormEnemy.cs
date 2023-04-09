using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormEnemy : BaseEnemy
{
    static List<TrojanEnemy> allTrojanEnemies = new List<TrojanEnemy>();
    static event EventHandler OnTrojanEnemyListChanged;

    [SerializeField] float speed = 1f;
    Transform targetTrojanEnemyTf;

    private void Start()
    {
        OnTrojanEnemyListChanged += SetTargetToNearestTrojanEnemy;
        SetTargetToNearestTrojanEnemy(this, EventArgs.Empty);
    }
    private void OnDestroy() {
        OnTrojanEnemyListChanged -= SetTargetToNearestTrojanEnemy;
    }

    private void FixedUpdate()
    {
        if (targetTrojanEnemyTf == null)
        {
            rb.velocity = Vector3.zero;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            return;
        }
        rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionY;
        rb.MovePosition(rb.position + (speed * Time.fixedDeltaTime * (targetTrojanEnemyTf.position - transform.position).normalized));
    }


    void SetTargetToNearestTrojanEnemy(object sender, EventArgs e)
    {
        targetTrojanEnemyTf = null;

        if(allTrojanEnemies.Count == 0)
        {
            return;
        }
        
        TrojanEnemy closestTrojanEnemy = allTrojanEnemies[0];
        float disBest = Vector3.Distance(transform.position, closestTrojanEnemy.transform.position);

        foreach (var trojanEnemy in allTrojanEnemies)
        {            
            float disNow = Vector3.Distance(transform.position , trojanEnemy.transform.position);

            if(disNow < disBest)
            {
                closestTrojanEnemy = trojanEnemy;
                disBest = disNow;
            }
        }
        targetTrojanEnemyTf = closestTrojanEnemy.transform;
    }

















    public static void AddTrojanEnemyToList(TrojanEnemy trojanEnemy)
    {
        allTrojanEnemies.Add(trojanEnemy);
        OnTrojanEnemyListChanged?.Invoke(null, EventArgs.Empty);
    }

    public static void RemoveTrojanEnemyFromList(TrojanEnemy trojanEnemy)
    {
        allTrojanEnemies.Remove(trojanEnemy);
        OnTrojanEnemyListChanged?.Invoke(null, EventArgs.Empty);
    }
}
