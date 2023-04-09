using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderEnemy : BaseEnemy
{    
    [SerializeField] float speed = 1f;
    Transform targetPlayerTf;

    private void Start() {
        targetPlayerTf = Player.Instance.transform;
    }

    private void FixedUpdate() {
        if(targetPlayerTf == null)
        {
            rb.velocity = Vector3.zero;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            return;
        }
        rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionY;
        rb.MovePosition(rb.position + (speed * Time.fixedDeltaTime * (targetPlayerTf.position- transform.position).normalized));
    }
}
