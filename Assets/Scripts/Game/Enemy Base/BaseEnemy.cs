using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public abstract class BaseEnemy : MonoBehaviour, IEnemy 
{
    public bool canChange = true;
    public float changeCooldown = 0.5f;
    [SerializeField]  int yanson = 4;

    protected Rigidbody rb;

    BaseEnemy lastHitted;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeAll;
        rb.velocity = Vector3.zero;
    }
    private void Start() {
        rb.constraints = RigidbodyConstraints.FreezeAll;
        rb.velocity = Vector3.zero;
    }


    public void OnCollisionStay(Collision other)
    {
        rb.constraints = RigidbodyConstraints.FreezeAll;
        rb.velocity = Vector3.zero;
        
        if(!canChange)
        {
            return;
        }

        if (other.gameObject.TryGetComponent<Bullet>(out Bullet bullet))
        {
            
            TryChangeEnemyType();
            return;
        }

        if (other.gameObject.TryGetComponent<BaseEnemy>(out BaseEnemy baseEnemy))
        {            
            if(this.GetType() == baseEnemy.GetType())
            {
                return;
            }  
                        
            TryChangeEnemyType();
            return;
        }
    }

    public void TryChangeEnemyType()
    {
        if(!canChange)
        {
            return;
        }
        gameObject.SetActive(false);
        canChange = false;
        BaseEnemy[] baseEnemies = AllEnemyTypeContainer.Instance.GetAllEnemyTypes();
        BaseEnemy newEnemy = this;
        for (int i = 0; i < baseEnemies.Length; i++)
        {
            //Debug.Log((baseEnemies[i]).GetType());
            if(this.GetType() == baseEnemies[i].GetType())
            {
                newEnemy = baseEnemies[(i+1)%baseEnemies.Length];
                break;
            }
        }

        if(newEnemy.GetType() == this.GetType())
        {
            return;
        }

        

        BaseEnemy newEnemyBE = Instantiate(newEnemy, transform.position,transform.rotation);
        newEnemyBE.canChange = false;        
        newEnemyBE.StartCoroutine("AfterChange");
        Destroy(gameObject);        
    }

    IEnumerator AfterChange()
    {
        Color old = GetComponentInChildren<SpriteRenderer>().material.color;
        GetComponentInChildren<SpriteRenderer>().material.DOColor(new Color(old.r,old.g,old.b,0.6f), changeCooldown/yanson).SetLoops(yanson,LoopType.Yoyo);
        //RENGİNİ DEĞİŞTİR
        yield return new WaitForSeconds(changeCooldown);
        canChange = true;
    }
}
