using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        GetComponent<Rigidbody>().velocity = Vector3.zero;

        if (other.gameObject.TryGetComponent<Bullet>(out Bullet bullet))
        {
            
            
            Destroy(bullet.gameObject);
            GetComponent<PlayerShoot>().bulletCount++;
            UIManager.Instance.SetMermiText(GetComponent<PlayerShoot>().bulletCount);
        }

        
    }

    private void OnCollisionStay(Collision other) {
        if (other.gameObject.TryGetComponent<BaseEnemy>(out BaseEnemy baseEnemy))
        {
            //Debug.Log("ÖLDÜN");
            GetComponent<HealthSystem>().Damage();
        }
    }
}
