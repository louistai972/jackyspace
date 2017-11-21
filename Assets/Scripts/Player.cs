using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour, ITakeDamage
{

    public float VitesseInit = 10f;
    public float SpeedUp = 1f;

    public SpawnProjectile LeftSpawner;
    public SpawnProjectile RightSpawner;

    public float StraffMaxSpeed = 100f;
    public float StraffTime = 0.1f;

    private Rigidbody _rigidbody;
    private float _smoothXVelocity;

    public float _currentHealth = 1;

    public Projectile ProjectilePrefab;
    public int Ammo = 3;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        Assert.IsNotNull(_rigidbody);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (Ammo <= 0)
            {
                return;
            }
            else
            {
                LeftSpawner.SpawnProjectiles();
                RightSpawner.SpawnProjectiles();
                Ammo--;
            }

        }
    }

    private void FixedUpdate()
    {
        Vector3 newVelocity = _rigidbody.velocity;
            newVelocity.z += VitesseInit * SpeedUp * Time.fixedDeltaTime;

			float targetVelocity = Input.GetAxis("Horizontal") * StraffMaxSpeed;

			newVelocity.x = Mathf.SmoothDamp(newVelocity.x,targetVelocity, ref _smoothXVelocity, StraffTime);


			_rigidbody.velocity = newVelocity;

        if (Input.GetKeyDown("space") && SpeedUp == 1F)
        {
            SpeedUp = 20f;
        }

        if (Input.GetKeyUp("space") && SpeedUp == 20f)
        {
            SpeedUp = 1F;
        }
    }

	private void LateUpdate()
	{
		
	}

    public void Kill()
    { 
     
     LevelManager.Instance.PlayerDeath();
        
    }

    public void TakeDamage(float damage, GameObject instigator)
    {
        _currentHealth -= damage;
        Debug.Log(_currentHealth);
        if (_currentHealth <= 0f)
        {
            Kill();
        }

    }
}
