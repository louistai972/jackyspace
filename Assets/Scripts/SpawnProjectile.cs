using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class SpawnProjectile : MonoBehaviour {

    public Projectile ProjectilePrefab;
    private Rigidbody _rigidbody;


    // Use this for initialization
    void Start () {
		
	}

    private void Awake()
    {
        Assert.IsNotNull(ProjectilePrefab);
        _rigidbody = GetComponentInParent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            SpawnProjectiles();
        }
    }

    private void SpawnProjectiles()
    {
        Projectile projectile = (Projectile)Instantiate(ProjectilePrefab, transform.position, Quaternion.identity);
        Vector3 initialVelocity = _rigidbody.velocity;
        initialVelocity.x = 0f;
        initialVelocity.y = 0f;
        projectile.Fire(_rigidbody.velocity);
    }
}
