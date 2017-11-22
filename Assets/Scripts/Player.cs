using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour, ITakeDamage
{
    public HUDHandler UiHandler;

    public float VitesseInit = 10f;
    private float SpeedUp = 1f;

    public SpawnProjectile LeftSpawner;
    public SpawnProjectile RightSpawner;

    public float StraffMaxSpeed = 100f;
    public float StraffTime = 0.1f;

    private Rigidbody _rigidbody;
    private float _smoothXVelocity;

    public float MaxHealth = 3f;
    public float CurrentHealth;

    public Projectile ProjectilePrefab;
    public int Ammo = 3;

    public Animator _animatorG;
    public Animator _animatorD;

    public int Score { get; private set; }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        Assert.IsNotNull(_rigidbody);

        //Assert.IsNotNull(UiHandler);
    }

    private void Start()
    {
        CurrentHealth = MaxHealth;
        Score = 0;
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

        if (Input.GetButtonDown("q"))
        {
            _animatorG.SetTrigger("Gauche");
        }

        if (Input.GetButtonDown("d"))
        {
            _animatorD.SetTrigger("Droite");
        }
    }

    private void FixedUpdate()
    {
        Vector3 newVelocity = _rigidbody.velocity;
        newVelocity.z = VitesseInit * SpeedUp;

        if (Input.GetKeyDown("z") && SpeedUp == 1f)
        {
            SpeedUp = 1.5f;
        }
        if (Input.GetKeyUp("z") && SpeedUp == 1.5f)
        {
            SpeedUp = 1f;
        }
        if (Input.GetKeyDown("s") && SpeedUp == 1f)
        {
            SpeedUp = 0.5f;
        }
        if (Input.GetKeyUp("s") && SpeedUp == 0.5f)
        {
            SpeedUp = 1f;
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
        CurrentHealth -= damage;
        //UiHandler.TakeDamage();
        Debug.Log(CurrentHealth);
        if (CurrentHealth <= 0f)
        {
            Kill();
        }

    }

    public void AddScore(int scoreValue)
    {
        Score += scoreValue;
    }
}
