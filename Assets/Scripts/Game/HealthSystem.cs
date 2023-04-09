using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class HealthSystem : MonoBehaviour
{
    [SerializeField] public int health = 3;
    [SerializeField]  float cooldown = 0.5f;
    [SerializeField] int yanson = 4;

    float timer = 0f;

    public bool canDamage  = true;

    private void Start() {
        UIManager.Instance.SetCanText(health);
    }

    private void Update() {
        timer += Time.deltaTime;
        if(timer >= cooldown)
        {
            canDamage = true;
        }


    }



    public void Damage()
    {
        if(!canDamage)
        {
            return;
        }

        canDamage = false;
        timer = 0;
        health--;
        Color old = GetComponentInChildren<SpriteRenderer>().material.color;
        //Debug.Log(old);
        
        GetComponentInChildren<SpriteRenderer>().material.DOColor(new Color(old.r,0,0,old.a), cooldown/yanson).SetLoops(yanson, LoopType.Yoyo);
        UIManager.Instance.SetCanText(health);
        if(health<= 0)
        {
            Dead();
        }
    }

    void Dead(){
        //Debug.Log("öldün");
        GetComponent<TimeManager>().SetIsEnded();
        
        
    }
}
