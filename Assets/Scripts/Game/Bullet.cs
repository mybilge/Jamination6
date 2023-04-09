using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody _rb;
    public Vector3 _velocity;
    void Awake()
    {
        _rb = this.GetComponent<Rigidbody>();
    }

    private void FixedUpdate() {
        _rb.velocity = _velocity;
    }

    void OnCollisionEnter(Collision collision)
    {
        ReflectProjectile(_rb, collision.contacts[0].normal);
    }

    private void OnTriggerExit(Collider other) {
        GetComponent<Collider>().isTrigger = false;
    }

    private void ReflectProjectile(Rigidbody rb, Vector3 reflectVector)
    {
        _velocity = Vector3.Reflect(_velocity, reflectVector);
        _rb.velocity = _velocity;
    }
}
