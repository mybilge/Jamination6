using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float bulletForce = 20f;
    public int bulletCount = 2;

    // Update is called once per frame

    private void Start() {
        UIManager.Instance.SetMermiText(bulletCount);
    }
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            HandleShoot();            
        }        
    }

    void HandleShoot()
    {
        if(bulletCount<=0)
        {
            return;
        }
        bulletCount--;
        UIManager.Instance.SetMermiText(bulletCount);

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 dir = mousePosition - transform.position;
        Vector3 shootOrigin = transform.position;
        dir.y = 0;
        dir.Normalize();
        GameObject bullet = Instantiate(bulletPrefab, shootOrigin, transform.rotation);
        bullet.GetComponent<Bullet>()._velocity = bulletForce * dir;
        bullet.GetComponent<Rigidbody>().velocity = bulletForce * dir;
        bullet.GetComponent<Collider>().isTrigger = true;
    }

    
}
