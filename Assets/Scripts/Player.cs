using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour, ITakeDamage
{
    public HUDhander UiHandler;

    public float VitesseInit = 10f;
    private float SpeedUp = 1f;

    public SpawnProjectile LeftSpawner;
    public SpawnProjectile RightSpawner;

    public float StraffMaxSpeed = 100f;
    public float StraffTime = 0.1f;

    private Rigidbody _rigidbody;
    private float _smoothXVelocity;

    public static ChangementCamera Instance { get; private set; }

    public GameObject CameraFPS;
    public GameObject CameraTOP;
    public GameObject CameraTPS;
    private int activeCamera = 0;
    public GameObject _currentCamera;

    public float MaxHealth = 3f;
    public float CurrentHealth;

    public Projectile ProjectilePrefab;
    public int Ammo = 3;

    public ParticleSystem Booster1;
    public ParticleSystem Booster2;

    public Animator _animator;

    public int Score { get; private set; }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        Assert.IsNotNull(_rigidbody);
        _currentCamera = CameraTOP;

        //Assert.IsNotNull(UiHandler);
    }

    private void Start()
    {
        CurrentHealth = MaxHealth;
        Score = 0;
        Booster1.Play();
        Booster2.Play();

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

        if (Input.GetKeyDown("q"))
        {
            _animator.SetTrigger("Gauche");
        }

        if (Input.GetKeyDown("d"))
        {
            _animator.SetTrigger("Droite");
        }
    }

    private void FixedUpdate()
    {
        Vector3 newVelocity = _rigidbody.velocity;
        newVelocity.z = VitesseInit * SpeedUp;

        if (Input.GetKeyDown("space") && SpeedUp == 1f)
        {
            //_currentCamera.transform.position.new Vector3(0f, 0f, -3f);
            SpeedUp = 3f;
        }
        if (Input.GetKeyUp("space") && SpeedUp == 3f)
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

    void ChangeCamera()
    {
        if (Input.GetKeyDown("c"))
        {
            if (activeCamera == 0)
            {

                CameraTOP.SetActive(false);
                CameraTPS.SetActive(true);
                activeCamera += 1;
                _currentCamera = CameraTPS;
                return;

            }
            if (activeCamera == 1)
            {

                CameraTPS.SetActive(false);
                CameraFPS.SetActive(true);
                activeCamera += 1;
                _currentCamera = CameraFPS;
                return;

            }
            if (activeCamera == 2)
            {

                CameraFPS.SetActive(false);
                CameraTOP.SetActive(true);
                activeCamera = 0;
                _currentCamera = CameraTOP;
                return;

            }
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
