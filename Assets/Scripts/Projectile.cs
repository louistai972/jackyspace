using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Projectile : MonoBehaviour {


    public float Damage = 1f;
    private Rigidbody _rigibody;

    private void Awake()
    {
        _rigibody = GetComponent<Rigidbody>();
        Assert.IsNotNull(_rigibody);
    }

    public void Fire(Vector3 initialVelocity)
    {
        _rigibody.velocity = initialVelocity;
        Destroy(gameObject, 3);

    }

    public void OnCollisionEnter(Collision collision)
    {
        ITakeDamage damageable = collision.gameObject.GetComponentInParent<ITakeDamage>();
        if(damageable != null)
        {
            damageable.TakeDamage(Damage, this.gameObject);

        }
        
    }
}
