using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour, ITakeDamage
{

    public float MaxSpeed = 100f;
    private float ForwardAcceleration = 20f;
    public float SpeedUp = 1f;
    private float _currentSpeed;


    public SpawnProjectile LeftSpawner;
    public SpawnProjectile RightSpawner;

    public float StraffMaxSpeed = 100f;
    public float StraffTime = 0.1f;

    private Rigidbody _rigidbody;
    private float _smoothXVelocity;

    public float _currentHealth = 1;

    public Projectile ProjectilePrefab;
    public int Ammo = 3;
    public int Shield = 2;

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
        if (Input.GetKeyDown("space") && SpeedUp == 1F)
        {
            SpeedUp = 300F;
        }

        if (Input.GetKeyUp("space") && SpeedUp == 300F)
        {
            SpeedUp = 1F;
        }

        Vector3 newVelocity = _rigidbody.velocity;
		if(newVelocity.z > MaxSpeed)
			{
				newVelocity.z = MaxSpeed;
			}
			else 
			{
            newVelocity.z += ForwardAcceleration * SpeedUp * Time.fixedDeltaTime;
			}

			float targetVelocity = Input.GetAxis("Horizontal") * StraffMaxSpeed;

			newVelocity.x = Mathf.SmoothDamp(newVelocity.x,targetVelocity, ref _smoothXVelocity, StraffTime);


			_rigidbody.velocity = newVelocity;
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
